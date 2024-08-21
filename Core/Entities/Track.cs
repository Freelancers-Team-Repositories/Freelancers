namespace Freelancers.Core.Entities;
public class Track
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public ICollection<FreelancerTrack> FreelancerTracks { get; set; } = [];
    public ICollection<TrackTechnology> TrackTechnologies { get; set; } = [];
    public ICollection<Task> Tasks { get; set; } = [];
}
