namespace Freelancers.Core.Entities;
public class FreelancerTechnology
{
    public string FreelancerId { get; set; } = null!;
    public int TechnologyId { get; set; }

    public ApplicationUser Freelancer { get; set; } = new();
    public Technology Technology { get; set; } = new();
}
