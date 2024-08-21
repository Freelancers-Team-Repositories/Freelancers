using Freelancers.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Freelancers.Repository.Persistence;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    public DbSet<FreelancerProject> FreelancerProjects { get; set; }
    public DbSet<FreelancerTask> FreelancerTasks { get; set; }
    public DbSet<FreelancerTechnology> FreelancerTechnologys { get; set; }
    public DbSet<FreelancerTrack> FreelancerTracks { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTechnology> ProjectTechnologys { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<SubImage> SubImages { get; set; }
    public DbSet<Core.Entities.Task> Tasks { get; set; }
    public DbSet<Technology> Technologys { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackTechnology> TrackTechnologys { get; set; }
}