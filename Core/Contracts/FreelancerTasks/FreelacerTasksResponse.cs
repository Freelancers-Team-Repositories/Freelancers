using Freelancers.Core.Contracts.Status;
using Freelancers.Core.Contracts.Tasks;
using Freelancers.Core.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancers.Core.Contracts.FreelancerTasks
{
    public record FreelacerTasksResponse
   (
     int id,
     DateTime? StartAt,
     DateTime? EndAt,
     UserBasicInfoResponse Freelancer,
     TaskResponse Task,
     StatusResponse Status,
     DateTime CreatedOn,
     DateTime LastUpdatedOn,
     UserBasicInfoResponse CreatedBy,
     UserBasicInfoResponse? UpdatedBy
        );
}
