using Freelancers.Core.Contracts.FreelancerTasks;

namespace Freelancers.Api.Validators.FreelancerTasks
{
    public class CreateFreelancerTasksValidator: AbstractValidator<CreateFreelancerTasksRequest>
    {
        public CreateFreelancerTasksValidator()
        {
            RuleFor(x => x.CreatedOn).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.TaskId).NotEmpty();
            RuleFor(x => x.StatusId).NotEmpty();
            RuleFor(x => x.CreatedById).NotEmpty();
            RuleFor(x => x.FreelancerId).NotEmpty();
        }
        
    }
}
