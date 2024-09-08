using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancers.Core.Contracts.Tasks
{
    public record UpdateTaskRequest
    (
        string Description,
        bool IsFinished,
        DateTime LastUpdatedOn,
        string? UpdatedById
    );
}
