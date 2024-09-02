using Freelancers.Core.Contracts.Authentication;
using Freelancers.Core.Entities;
using Freelancers.Core.Interfaces;
using Freelancers.Service.Helpers;
using Freelancers.Shared.Abstraction;
using Freelancers.Shared.Abstraction.Const;
using Freelancers.Shared.Errors;
using Hangfire;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Freelancers.Service;
public class AuthService(
    UserManager<ApplicationUser> userManager,
    IJwtProvider jwtProvider,
    IEmailSender emailSender,
    SignInManager<ApplicationUser> signInManager,
    IHttpContextAccessor httpContextAccessor) : IAuthService
{

    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IEmailSender _emailSender = emailSender;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        #region check User		
        if (await _userManager.FindByEmailAsync(email) is not { } user)
            return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

        #endregion

        #region check password with email confimation		
        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

        if (result.Succeeded)
        {

            var userRoles = await _userManager.GetRolesAsync(user);
            var jwtResult = _jwtProvider.GenerateToken(user, userRoles);


            await _userManager.UpdateAsync(user);


            var response = new AuthResponse(
                user.Id,
                user.Email!,
                user.FirstName,
                user.LastName,
                jwtResult.token,
                userRoles,
                DateTime.UtcNow.AddHours(jwtResult.expiresIn)
            );

            return Result.Success<AuthResponse>(response);
        }
        #endregion


        return Result.Failure<AuthResponse>(result.IsNotAllowed ? UserErrors.EmailNotConfirmed : UserErrors.InvalidCredentials);
    }

    public async Task<Result> RegisterAsync(SignUpRequest request, CancellationToken cancellationToken)
    {
        var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email);
        if (emailIsExists)
            return Result.Failure(UserErrors.DuplicatedEmail);

        var user = request.Adapt<ApplicationUser>();

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            await SendConfirmationEmail(user, code);

            return Result.Success();
        }


        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }


    public async Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request)
    {
        if (await _userManager.FindByIdAsync(request.UserId) is not { } user)
            return Result.Failure(UserErrors.InvalidCode);

        if (user.EmailConfirmed)
            return Result.Failure(UserErrors.DuplicatedConfirmation);

        var code = request.Code;
        try
        {
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        }
        catch (FormatException)
        {
            return Result.Failure(UserErrors.InvalidCode);
        }

        var result = await _userManager.ConfirmEmailAsync(user, code);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, DefaultRoles.Customer);
            return Result.Success();
        }


        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }


    public async Task<Result> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest request)
    {
        if (await _userManager.FindByEmailAsync(request.Email) is not { } user)
            return Result.Success();

        if (user.EmailConfirmed)
            return Result.Failure(UserErrors.DuplicatedConfirmation);

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));


        await SendConfirmationEmail(user, code);

        return Result.Success();
    }


    public async Task<Result> SendResetPasswordCodeAsync(string email)
    {
        if (await _userManager.FindByEmailAsync(email) is not { } user)
            return Result.Success();

        if (!user.EmailConfirmed)
            return Result.Failure(UserErrors.EmailNotConfirmed);

        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        await SendResetPasswordEmail(user, code);

        return Result.Success();
    }


    public async Task<Result> ResetPasswordAsync(ResetPasswordRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null || !user.EmailConfirmed)
            return Result.Failure(UserErrors.InvalidCode);

        IdentityResult result;

        try
        {
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));

            result = await _userManager.ResetPasswordAsync(user, code, request.NewPassword);
        }
        catch (FormatException)
        {
            result = IdentityResult.Failed(_userManager.ErrorDescriber.InvalidToken());
        }


        if (result.Succeeded)
            return Result.Success();


        var error = result.Errors.First();
        return Result.Failure(new(error.Code, error.Description, StatusCodes.Status401Unauthorized));
    }



    private async System.Threading.Tasks.Task SendConfirmationEmail(ApplicationUser user, string code)
    {
        var origin = _httpContextAccessor.HttpContext?.Request.Headers.Origin;

        var emailBody = EmailBodyBuilder.GenerateEmailBody("EmailConfirmation.html",
            templateModel: new Dictionary<string, string>
            {
                {"{{name}}" , user.FirstName },
                {"{{action_url}}" , $"{origin}/confirmEmail?userId={user.Id}&code={code}" },
            }
        );

        BackgroundJob.Enqueue(() => _emailSender.SendEmailAsync(user.Email!, "✅ Freelancers: Email Confirmation", emailBody));

        await System.Threading.Tasks.Task.CompletedTask;
    }

    private async System.Threading.Tasks.Task SendResetPasswordEmail(ApplicationUser user, string code)
    {

        var origin = _httpContextAccessor.HttpContext?.Request.Headers.Origin;

        var emailBody = EmailBodyBuilder.GenerateEmailBody("ForgetPassword.html",
            templateModel: new Dictionary<string, string>
            {
                {"{{name}}" , user.FirstName },
                {"{{action_url}}" , $"{origin}/resetPassword?email={user.Email}&code={code}" },
            }
        );


        BackgroundJob.Enqueue(() =>
             _emailSender.SendEmailAsync(user.Email!, "✅ Freelancers: Change Password", emailBody)
        );

        await System.Threading.Tasks.Task.CompletedTask;
    }
}
