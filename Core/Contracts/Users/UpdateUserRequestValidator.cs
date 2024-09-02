using FluentValidation;

namespace Freelancers.Core.Contracts.Users;
public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
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


        RuleFor(x => x.Roles)
            .NotNull()
            .NotEmpty();


        RuleFor(x => x.Roles)
            .Must(x => x.Distinct().Count() == x.Count).WithMessage("You cannot duplicated role for the same user")
            .When(x => x.Roles is not null);
    }
}
