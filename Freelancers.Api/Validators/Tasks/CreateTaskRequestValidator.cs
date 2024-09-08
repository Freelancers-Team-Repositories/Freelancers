using Freelancers.Core.Contracts.tasks;
using Freelancers.Core.Contracts.Tasks;


namespace Freelancers.Api.Validators.Tasks
{
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
    {
public CreateTaskRequestValidator()
        {
            RuleFor(x => x.CreatedOn).NotEmpty().LessThan(DateTime.Now); ;
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.TrackId).NotEmpty();
            RuleFor(x => x.CreatedById).NotEmpty();
        }
    }
}
