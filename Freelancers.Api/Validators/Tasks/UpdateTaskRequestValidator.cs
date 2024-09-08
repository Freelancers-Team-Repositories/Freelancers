using Freelancers.Core.Contracts.Tasks;

namespace Freelancers.Api.Validators.Tasks
{
    public class UpdateTaskRequestValidator: AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskRequestValidator()
        {
            RuleFor(x => x.IsFinished).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.UpdatedById).NotEmpty();
            RuleFor(x => x.LastUpdatedOn).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
