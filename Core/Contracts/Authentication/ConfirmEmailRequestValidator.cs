using FluentValidation;

namespace Freelancers.Core.Contracts.Authentication;

public class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
{
	public ConfirmEmailRequestValidator()
	{
		RuleFor(x => x.UserId)
			.NotEmpty();

		RuleFor(x => x.Code)
			.NotEmpty();
	}
}
