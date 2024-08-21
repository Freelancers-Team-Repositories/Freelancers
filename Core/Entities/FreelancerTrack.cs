namespace Freelancers.Core.Entities
{
    public class FreelancerTrack
    {
        public string FreelancerId { get; set; } = null!;
        public ApplicationUser Freelancer { get; set; } = new();
        public int TrackId { get; set; }
        public Track Track { get; set; } = new();
    }
}