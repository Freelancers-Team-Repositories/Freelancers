namespace Freelancers.Core.Entities;
public class FreelancerTask
{
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }

    public string FreelancerId { get; set; } = null!;
    public int TaskId { get; set; }
    public int StatusId { get; set; }


    public ApplicationUser Freelancer { get; set; } = new();
    public Task Task { get; set; } = new();
    public Status Status { get; set; } = new();
}