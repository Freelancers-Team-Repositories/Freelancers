using Microsoft.AspNetCore.Identity;

namespace Freelancers.Core.Entities;
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateOnly DateOfBirth { get; set; }
    public ICollection<FreelancerTechnology> FreelancerTechnologies { get; set; } = [];
    public ICollection<FreelancerTrack> FreelancerTracks { get; set; } = [];
    public ICollection<FreelancerProject> FreelancerProjects { get; set; } = [];
    public ICollection<FreelancerTask> FreelancerTasks { get; set; } = [];
}