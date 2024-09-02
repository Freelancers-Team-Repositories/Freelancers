namespace Freelancers.Core.Contracts.Users;
public record UserResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    DateOnly DateOfBirth,
    bool IsActive,
    string ImageUrl,
    IEnumerable<string> Roles
);
