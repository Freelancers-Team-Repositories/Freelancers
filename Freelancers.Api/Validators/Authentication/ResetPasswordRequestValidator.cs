using Freelancers.Core.Contracts.Authentication;
using Freelancers.Shared.Abstraction.Const;

namespace Freelancers.Api.Validators.Authentication;

public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();


        RuleFor(x => x.Code)
            .NotEmpty();


        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .Matches(RegexPatterns.Password).WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase");

    }
}

