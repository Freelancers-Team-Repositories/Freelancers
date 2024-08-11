using Freelancers.Api.Contracts.Authentication;

namespace Freelancers.Api.Services;

public interface IAuthService
{
	Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);

	Task<Result> RegisterAsync(SignUpRequest request, CancellationToken cancellationToken);

	Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request);
	Task<Result> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest request);
}
