using Freelancers.Core.Contracts.Users;
using Freelancers.Shared.Abstraction.Const;

namespace Freelancers.Api.Validators.Users;
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();


        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .Must(x => x < DateOnly.FromDateTime(DateTime.Now));

        RuleFor(x => x.Password)
            .NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase");


        RuleFor(x => x.Tracks)
            .NotEmpty()
            .Must(x => x.Distinct().Count() == x.Count).WithMessage("You cannot duplicated track for the same user")
            .When(x => x.Tracks is not null);


        RuleFor(x => x.Roles)
            .NotEmpty()
            .Must(x => x.Distinct().Count() == x.Count).WithMessage("You cannot duplicated role for the same user")
            .When(x => x.Roles is not null);
    }
}
