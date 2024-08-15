using Freelancers.Api.Contracts.Users;

namespace Freelancers.Api.Services;

public interface IUserService
{
	Task<Result<UserProfileResponse>> GetProfileAsync(string userId);

	Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request);

	Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request);
}
