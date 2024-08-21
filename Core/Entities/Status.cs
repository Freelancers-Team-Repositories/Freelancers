namespace Freelancers.Core.Entities;
public class Status
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;   
    public ICollection<FreelancerTask> FreelancerTasks { get; set; } = [];
}
