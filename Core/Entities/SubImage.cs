namespace Freelancers.Core.Entities
{
    public class SubImage
    {
        public int Id { get; set; } 
        public string Url { get; set; } = null!;
        public int ProjectId { get; set; }
        public Project Project { get; set; } = new();
    }
}