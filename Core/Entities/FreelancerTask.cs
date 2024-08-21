namespace Freelancers.Core.Entities;
public class FreelancerTask
{
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string FreelancerId { get; set; } = null!;
    public ApplicationUser Freelancer { get; set; } = new();
    public int TaskId { get; set; }
    public Task Task { get; set; } = new();
    public int StatusId { get; set; }
    public Status Status { get; set; } = new();
}