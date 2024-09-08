namespace Freelancers.Core.Contracts.tasks;

public record CreateTaskRequest(

    string Description,
    DateTime CreatedOn,
    string CreatedById,
    int TrackId
)
   
;

