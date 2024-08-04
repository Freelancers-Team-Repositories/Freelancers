namespace Freelancers.Api.Contracts.Authentication;

public record AuthResponse(
	string id,
	string Email,
	string FirstName,
	string LastName,
	string Token,
	DateTime ExpiresIn
);
