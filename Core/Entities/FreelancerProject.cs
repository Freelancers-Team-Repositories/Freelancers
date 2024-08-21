namespace Freelancers.Core.Entities;
public class FreelancerProject
{
    public string FreelancerId { get; set; } = null!;
    public ApplicationUser Freelancer { get; set; } = new();
    public int ProjectId { get; set; }
    public Project Project { get; set; } = new();
}
