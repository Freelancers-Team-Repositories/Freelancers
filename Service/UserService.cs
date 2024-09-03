using Freelancers.Core.Contracts.Tracks;
using Freelancers.Core.Contracts.Users;
using Freelancers.Core.Entities;
using Freelancers.Core.Interfaces;
using Freelancers.Core.Interfaces.UnitOfWork;
using Freelancers.Repository.Persistence;
using Freelancers.Shared.Abstraction;
using Freelancers.Shared.Abstraction.Const;
using Freelancers.Shared.Errors;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Common;

namespace Freelancers.Service;

public class UserService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, ApplicationDbContext _context, RoleManager<ApplicationRole> _roleManager) : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;



    public async Task<Result<UserProfileResponse>> GetProfileAsync(string userId)
    {
        var user = await _unitOfWork.Repository<ApplicationUser>().GetByIdAsync(userId);

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




    public async Task<Result<IEnumerable<UserResponse>>> GetAllAsync()
    {
        var users = await (from u in _context.Users
                           join ur in _context.UserRoles
                           on u.Id equals ur.UserId
                           join r in _context.Roles
                           on ur.RoleId equals r.Id into roles
                           where !roles.Any(x => x.Name == DefaultRoles.Customer)
                           select new
                           {
                               u.Id,
                               u.FirstName,
                               u.LastName,
                               u.Email,
                               u.DateOfBirth,
                               u.IsActive,
                               u.ImageUrl,
                               Tracks = u.FreelancerTracks.Select(x => new TrackResponse(x.TrackId, x.Track.Name)),
                               Roles = roles.Select(x => x.Name!).ToList()
                           })
                           .GroupBy(user => new { user.Id, user.FirstName, user.LastName, user.Email, user.IsActive, user.DateOfBirth, user.ImageUrl })
                           .Select(user => new UserResponse
                           (
                               user.Key.Id,
                               user.Key.FirstName,
                               user.Key.LastName,
                               user.Key.Email,
                               user.Key.DateOfBirth,
                               user.Key.IsActive,
                               user.Key.ImageUrl,
                               user.SelectMany(x => x.Tracks),
                               user.SelectMany(x => x.Roles)
                           ))
                           .ToListAsync();


        return Result.Success(users.Adapt<IEnumerable<UserResponse>>());
    }

    public async Task<Result<UserResponse>> GetAsync(string id)
    {
        if (await _userManager.Users.Include(x => x.FreelancerTracks).ThenInclude(x => x.Track).SingleOrDefaultAsync(x => x.Id == id) is not { } user)
            return Result.Failure<UserResponse>(UserErrors.UserNotFound);

        var userRoles = await _userManager.GetRolesAsync(user);

        var response = (user, userRoles).Adapt<UserResponse>();

        return Result.Success(response);
    }


    public async Task<Result<UserResponse>> AddAsync(CreateUserRequest request)
    {
        var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email);
        if (emailIsExists)
            return Result.Failure<UserResponse>(UserErrors.DuplicatedEmail);


        var allowedRoles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();
        if (request.Roles.Except(allowedRoles).Any())
            return Result.Failure<UserResponse>(UserErrors.InvalidRoles);

        var allowedTracks = await _unitOfWork.Repository<Track>().GetAllAsync();
        if (request.Tracks.Except(allowedTracks.Select(x => x.Id)).Any())
            return Result.Failure<UserResponse>(TrackErrors.InvalidTracks);


        var user = request.Adapt<ApplicationUser>();
        var result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            user.FreelancerTracks.AddRange(request.Tracks.Select(trackId => new FreelancerTrack() { TrackId = trackId }));



            await _userManager.AddToRolesAsync(user, request.Roles);

            var response = (user, request.Roles).Adapt<UserResponse>();

            return Result.Success(response);
        }


        var error = result.Errors.First();

        return Result.Failure<UserResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> UpdateAsync(string id, UpdateUserRequest request)
    {
        var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id);
        if (emailIsExists)
            return Result.Failure(UserErrors.DuplicatedEmail);


        var allowedRoles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();
        if (request.Roles.Except(allowedRoles).Any())
            return Result.Failure(UserErrors.InvalidRoles);


        var allowedTracks = await _unitOfWork.Repository<Track>().GetAllAsync();
        if (request.Tracks.Except(allowedTracks.Select(x => x.Id)).Any())
            return Result.Failure<UserResponse>(TrackErrors.InvalidTracks);


        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure(UserErrors.UserNotFound);


        user = request.Adapt(user);


        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            await _context.UserRoles
                .Where(x => x.UserId == id)
                .ExecuteDeleteAsync();

            await _context.FreelancerTracks
                .Where(x => x.FreelancerId == id)
                .ExecuteDeleteAsync();


            user.FreelancerTracks.AddRange(request.Tracks.Select(x => new FreelancerTrack() { TrackId = x }));
            await _userManager.AddToRolesAsync(user, request.Roles);


            return Result.Success();
        }


        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }


    public async Task<Result> ToggleStatusAsync(string id)
    {
        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure(UserErrors.UserNotFound);

        await _context.Users
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(setter => setter.SetProperty(x => x.IsActive, x => !x.IsActive));

        return Result.Success();
    }

}
