namespace Freelancers.Core.Entities;
public class BaseEntity
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? LastUpdatedOn { get; set; }
    public string CreatedById { get; set; } = null!;
    public ApplicationUser CreatedBy { get; set; } = new();
    public string? UpdatedById { get; set; }    
    public ApplicationUser? UpdatedBy { get; set; }
}
