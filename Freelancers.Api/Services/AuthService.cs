using Freelancers.Api.Authentication;
using Freelancers.Api.Contracts.Authentication;


namespace Freelancers.Api.Services;

public class AuthService(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider) : IAuthService
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly IJwtProvider _jwtProvider = jwtProvider;

	public async Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
	{
		#region check User
		var user = await _userManager.FindByEmailAsync(email);
		if (user is null)
			return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);
		#endregion

		#region check password
		var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
		if (!isValidPassword)
			return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);
		#endregion

		#region Check Email Confimation
		if (!user.EmailConfirmed)
			return Result.Failure<AuthResponse>(UserErrors.EmailNotConfirmed);
		#endregion


		var jwtResult = _jwtProvider.GenerateToken(user);

		var response = new AuthResponse(user.Id, user.Email!, user.FirstName, user.LastName, jwtResult.token, DateTime.UtcNow.AddHours(jwtResult.expiresIn));

		return Result.Success(response);
	}


}
