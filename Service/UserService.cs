using Freelancers.Api.Services;
using Freelancers.Core.Contracts.Users;
using Freelancers.Core.Entities;
using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Shared.Abstraction;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Freelancers.Service;

public class UserService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    public async Task<Result<UserProfileResponse>> GetProfileAsync(string userId)
    {
        /*var user = await _userManager.Users
            .Where(x => x.Id == userId)
            .ProjectToType<UserProfileResponse>()
            .SingleAsync();*/

        var user = await _unitOfWork.Users.GetByIdAsync(userId);



        return Result.Success(user.Adapt<UserProfileResponse>());
    }

    public async Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request)
    {
        await _userManager.Users
                    .Where(x => x.Id == userId)
                    .ExecuteUpdateAsync(setters =>
                        setters
                            .SetProperty(x => x.FirstName, request.FirstName)
                            .SetProperty(x => x.LastName, request.LastName)
                    );

        return Result.Success();
    }

    public async Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        var user = await _userManager.FindByIdAsync(userId);

        var result = await _userManager.ChangePasswordAsync(user!, request.CurrentPassword, request.NewPassword);

        if (result.Succeeded)
            return Result.Success();


        var error = result.Errors.First();

        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }
}
