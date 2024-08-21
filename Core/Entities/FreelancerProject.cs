namespace Freelancers.Core.Entities;
public class FreelancerProject
{
    public string FreelancerId { get; set; } = null!;
    public int ProjectId { get; set; }

    public ApplicationUser Freelancer { get; set; } = new();
    public Project Project { get; set; } = new();
}
