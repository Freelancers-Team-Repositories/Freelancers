using Freelancers.Core.Contracts.Authentication;
using Freelancers.Shared.Abstraction;

namespace Freelancers.Core.Interfaces;
public interface IAuthService
{
    Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<Result> RegisterAsync(SignUpRequest request, CancellationToken cancellationToken);
    Task<Result> ConfirmEmailAsync(ConfirmEmailRequest request);
    Task<Result> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest request);
    Task<Result> SendResetPasswordCodeAsync(string email);
    Task<Result> ResetPasswordAsync(ResetPasswordRequest request);
}