
namespace Freelancers.Core.Entities;
public class FreelancerTrack
{
    public string FreelancerId { get; set; } = null!;
    public int TrackId { get; set; }


    public ApplicationUser Freelancer { get; set; } = default!;
    public Track Track { get; set; } = default!;
}