namespace Freelancers.Core.Entities
{
    public class ProjectTechnology
    {
        public int ProjectId { get; set; }
        public int TechnologyId { get; set; }

        public Project Project { get; set; } = new();
        public Technology Technology { get; set; } = new();
    }
}