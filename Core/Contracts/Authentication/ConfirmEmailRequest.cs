namespace Freelancers.Core.Contracts.Authentication;

public record ConfirmEmailRequest(
	string UserId,
	string Code
);
