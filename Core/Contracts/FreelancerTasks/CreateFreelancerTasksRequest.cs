using Freelancers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancers.Core.Contracts.FreelancerTasks
{
    public record CreateFreelancerTasksRequest
    (
     DateTime? StartAt ,
     string FreelancerId ,
     int TaskId ,
     int StatusId,
     DateTime CreatedOn,
     string CreatedById);

}
