using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancers.Core.Contracts.FreelancerTasks
{
    public record UpdateFreelancerTasksRequest
   (
     DateTime? StartAt,
     DateTime? EndAt,
     string FreelancerId,
     int TaskId,
     int StatusId,
     DateTime LastUpdatedOn,
     string? UpdatedById

        );
}
