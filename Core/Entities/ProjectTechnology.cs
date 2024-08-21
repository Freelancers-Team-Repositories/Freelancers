namespace Freelancers.Core.Entities
{
    public class ProjectTechnology
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; } = new Project();
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; } = new Technology();
    }
}