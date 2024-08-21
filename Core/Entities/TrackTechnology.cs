namespace Freelancers.Core.Entities;
public class TrackTechnology
{
    public int TrackId { get; set; }
    public int TechnologyId { get; set; }


    public Track Track { get; set; } = new();
    public Technology Technology { get; set; } = new();
}
