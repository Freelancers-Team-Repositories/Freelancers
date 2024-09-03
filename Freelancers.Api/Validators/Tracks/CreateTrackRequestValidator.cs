using Freelancers.Core.Contracts.Tracks;

namespace Freelancers.Api.Validators.Tracks;
public class CreateTrackRequestValidator : AbstractValidator<CreateTrackRequest>
{
    public CreateTrackRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 250);
    }
}
