using Freelancers.Core.Contracts.Users;
using Freelancers.Shared.Abstraction;

namespace Freelancers.Core.Interfaces;

public interface IUserService
{
    Task<Result<UserProfileResponse>> GetProfileAsync(string userId);
    Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request);
    Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request);

    Task<Result<IEnumerable<UserResponse>>> GetAllAsync();
    Task<Result<UserResponse>> AddAsync(CreateUserRequest request);
    Task<Result<UserResponse>> GetAsync(string id);
    Task<Result> UpdateAsync(string id, UpdateUserRequest request);
    Task<Result> ToggleStatusAsync(string id);
}
