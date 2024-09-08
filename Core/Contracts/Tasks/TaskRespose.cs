using Freelancers.Core.Contracts.Tracks;
using Freelancers.Core.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancers.Core.Contracts.Tasks
{
    public record TaskRespose
   (

        int Id,
        string Description,
        bool IsFinished,
        TrackResponse Track,
        CreatedByResponse CreatedBy,
        CreatedByResponse? UpdatedBy,
        DateTime CreatedDate,
        DateTime UpdatedDate
        
     );
}
