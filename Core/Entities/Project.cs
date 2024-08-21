namespace Freelancers.Core.Entities;
public class Project : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Summary { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string ProjectUrl { get; set; } = null!;
    public string? VideoUrl { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsActive { get; set; }
    public ICollection<SubImage> SubImages { get; set; } = [];
    public ICollection<ProjectTechnology> ProjectTechnologies { get; set; } = [];
    public ICollection<FreelancerProject> FreelancerProjects { get; set; } = [];
}