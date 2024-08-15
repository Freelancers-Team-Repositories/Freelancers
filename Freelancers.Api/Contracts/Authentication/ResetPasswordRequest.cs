namespace Freelancers.Api.Contracts.Authentication;

public record ResetPasswordRequest(
	string Email,
	string Code,
	string NewPassword
);
