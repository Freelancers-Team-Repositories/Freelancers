using Freelancers.Api.Contracts.Authentication;
using Freelancers.Api.Contracts.Const;
using Freelancers.Api.Entities;
using Freelancers.Api.Errors;
using Freelancers.Api.Services;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;

namespace Freelancers.Api.Controllers;


[Route("[controller]")]
[ApiController]
public class AuthController(UserManager<ApplicationUser> userManager, IAuthService authService, IEmailSender emailSender) : ControllerBase
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly IAuthService _authService = authService;
	private readonly IEmailSender _emailSender = emailSender;


	[HttpPost("SignUp")]
	public async Task<IActionResult> SignUp(SignUpRequest request, CancellationToken cancellationToken)
	{
		var user = request.Adapt<ApplicationUser>();

		var result = await _userManager.CreateAsync(user, request.Password);
		if (!result.Succeeded)
			return BadRequest(result.Errors.Select(x => x.Description));

		await _userManager.AddToRoleAsync(user, AppRoles.Customer);
		await SendEmailConfirmation(user.Email!);

		return Ok("Please check your email to confirm account");
	}


	[HttpPost("Login")]
	public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
	{
		var response = await _authService.GetTokenAsync(request.Email!, request.Password, cancellationToken);

		if (response.Error.Description.Equals(UserErrors.EmailNotConfirmed.Description))
			await SendEmailConfirmation(request.Email);

		return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
	}


	[HttpGet("ConfirmEmail")]
	public async Task<IActionResult> ConfirmEmail(string userId, string code)
	{
		if (userId is null || code is null)
			return BadRequest("Invalid Data");

		var user = await _userManager.FindByIdAsync(userId);
		if (user is null)
			return NotFound();

		code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
		var result = await _userManager.ConfirmEmailAsync(user, code);


		return result.Succeeded ? Ok("Email confirmed successfully") : BadRequest();
	}



	private async Task<bool> SendEmailConfirmation(string email)
	{
		var user = await _userManager.FindByEmailAsync(email);
		if (user is null)
			return false;

		var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
		code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

		var callbackUrl = Url.Action(
			action: "ConfirmEmail",
			controller: "Auth",
			values: new { userId = user.Id, code },
			protocol: Request.Scheme

		);

		var body = @$"<div>Click <a href='{HtmlEncoder.Default.Encode(callbackUrl!).ToString()}'> here </a> to confirm your account</div>";

		await _emailSender.SendEmailAsync(user.Email!, "Confirm your email", body);

		return true;
	}
}
