using Freelancers.Core.Contracts.Authentication;

namespace Freelancers.Api.Validators.Authentication;

public class ResendConfirmationEmailRequestValidator : AbstractValidator<ResendConfirmationEmailRequest>
{
    public ResendConfirmationEmailRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().EmailAddress();
    }
}
