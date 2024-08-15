namespace Freelancers.Api.Contracts.Users;

public record UpdateProfileRequest(
	string FirstName,
	string LastName
);
