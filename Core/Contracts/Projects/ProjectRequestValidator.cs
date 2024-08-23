
using FluentValidation;

namespace Freelancers.Core.Contracts.Projects;

public class ProjectRequestValidator : AbstractValidator<ProjectRequest>
{
    public ProjectRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();
    }
}
