using Freelancers.Core.Contracts.FreelancerTasks;

namespace Freelancers.Api.Validators.FreelancerTasks
{
    public class UpdateFreelancerTasksValidator: AbstractValidator<UpdateFreelancerTasksRequest>
    {
        public UpdateFreelancerTasksValidator()
        {
            RuleFor(x => x.LastUpdatedOn).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.TaskId).NotEmpty();
            RuleFor(x => x.StatusId).NotEmpty();
            RuleFor(x => x.UpdatedById).NotEmpty();
            RuleFor(x => x.FreelancerId).NotEmpty();
        }
    }
}
