namespace Freelancers.Api.Contracts.Users;

public record ChangePasswordRequest(
	string CurrentPassword,
	string NewPassword
);
