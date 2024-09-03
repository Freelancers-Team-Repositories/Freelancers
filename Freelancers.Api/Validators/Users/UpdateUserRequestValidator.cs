using Freelancers.Core.Contracts.Users;

namespace Freelancers.Api.Validators.Users;
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
