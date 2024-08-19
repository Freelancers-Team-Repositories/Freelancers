using FluentValidation;

namespace Freelancers.Core.Contracts.Authentication;

public class ResendConfirmationEmailRequestValidator : AbstractValidator<ResendConfirmationEmailRequest>
{
	public ResendConfirmationEmailRequestValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty().EmailAddress();
	}
}
