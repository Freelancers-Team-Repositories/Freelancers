namespace Freelancers.Core.Entities;

public class Task : BaseEntity
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public bool IsFinished { get; set; }
    public int TrackId { get; set; }

    public Track Track { get; set; } = new();
    public ICollection<FreelancerTask> FreelancerTasks { get; set; } = [];
}
