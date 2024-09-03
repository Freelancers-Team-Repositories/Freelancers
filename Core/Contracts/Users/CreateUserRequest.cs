namespace Freelancers.Core.Contracts.Users;
public record CreateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    DateOnly DateOfBirth,
    string Password,
    IList<int> Tracks,
    IList<string> Roles
);
