using Freelancers.Core.Contracts.Tracks;

namespace Freelancers.Core.Contracts.Users;
public record UserResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    DateOnly DateOfBirth,
    bool IsActive,
    string ImageUrl,
    IEnumerable<TrackResponse> Tracks,
    IEnumerable<string> Roles
);
