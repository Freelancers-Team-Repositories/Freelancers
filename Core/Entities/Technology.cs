namespace Freelancers.Core.Entities;
public class Technology
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<ProjectTechnology> ProjectTechnologies { get; set; } = [];
    public ICollection<TrackTechnology> TrackTechnologies { get; set; } = [];
    public ICollection<FreelancerTechnology> FreelancerTechnologies { get; set; } = [];
}