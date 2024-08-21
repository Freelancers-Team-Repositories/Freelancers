namespace Freelancers.Core.Entities;
public class TrackTechnology
{
    public int TrackId { get; set; }
    public Track Track { get; set; } = new Track();
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; } = new Technology();
}
