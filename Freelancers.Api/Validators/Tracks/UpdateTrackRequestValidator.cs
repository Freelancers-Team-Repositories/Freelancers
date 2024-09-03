using Freelancers.Core.Contracts.Tracks;

namespace Freelancers.Api.Validators.Tracks;

public class UpdateTrackRequestValidator : AbstractValidator<UpdateTrackRequest>
{
    public UpdateTrackRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 250);


    }
}
