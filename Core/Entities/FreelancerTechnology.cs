namespace Freelancers.Core.Entities;
public class FreelancerTechnology
{
    public string FreelancerId { get; set; } = null!;
    public ApplicationUser Freelancer { get; set; } = new();
    public int TechnologyId { get; set; }   
    public Technology Technology { get; set; } = new();
}
