using Freelancers.Api.Abstraction;
using Freelancers.Api.Contracts.Authentication;

namespace Freelancers.Api.Services;

public interface IAuthService
{
	Task<Result<AuthResponse>> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
}
