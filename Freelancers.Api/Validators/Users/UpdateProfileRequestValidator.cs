using Freelancers.Core.Contracts.Users;

namespace Freelancers.Api.Validators.Users;

public class UpdateProfileRequestValidator : AbstractValidator<UpdateProfileRequest>
{
    public UpdateProfileRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(3, 100);


        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(3, 100);
    }
}

