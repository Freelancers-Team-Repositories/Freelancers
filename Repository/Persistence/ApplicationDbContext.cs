using Freelancers.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Freelancers.Repository.Persistence;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{

    #region Db Sets
    public DbSet<FreelancerProject> FreelancerProjects { get; set; }
    public DbSet<FreelancerTask> FreelancerTasks { get; set; }
    public DbSet<FreelancerTechnology> FreelancerTechnologies { get; set; }
    public DbSet<FreelancerTrack> FreelancerTracks { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<SubImage> SubImages { get; set; }
    public DbSet<Core.Entities.Task> Tasks { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackTechnology> TrackTechnologies { get; set; }
    #endregion


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #region Change Delete Behavior From Cascade To Restrict
        var cascadeFKs = builder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        #endregion

        base.OnModelCreating(builder);
    }

}