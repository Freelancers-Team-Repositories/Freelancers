namespace Freelancers.Api.Contracts.Authentication;

public record AuthResponse(
	string Id,
	string Email,
	string FirstName,
	string LastName,
	string Token,
	IEnumerable<string> Roles,
	DateTime ExpiresIn
);
