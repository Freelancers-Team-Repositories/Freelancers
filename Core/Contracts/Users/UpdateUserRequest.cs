namespace Freelancers.Core.Contracts.Users;
public record UpdateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    DateOnly DateOfBirth,
    IList<int> Tracks,
    IList<string> Roles
);
