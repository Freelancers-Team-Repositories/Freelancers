namespace Freelancers.Core.Contracts.tasks;

public record CreateTrackRequest(
    string Description,

bool IsFinished,
    IList<int> Track,
    DateTime LastUpdatedOn,
    IList<int> CreatedBy,
    IList<int> UpdatedBy)
;

