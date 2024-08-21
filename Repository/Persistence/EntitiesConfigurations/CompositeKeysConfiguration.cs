using Freelancers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Repository.Persistence.EntitiesConfigurations;

public class ProjectTechnologyConfiguration : IEntityTypeConfiguration<ProjectTechnology>
{
    public void Configure(EntityTypeBuilder<ProjectTechnology> builder)
    {
        builder.HasKey(pt => new { pt.ProjectId, pt.TechnologyId });
    }
}

public class FreelancerTrackConfiguration : IEntityTypeConfiguration<FreelancerTrack>
{
    public void Configure(EntityTypeBuilder<FreelancerTrack> builder)
    {
        builder.HasKey(ft => new { ft.FreelancerId, ft.TrackId });
    }
}

public class TrackTechnologyConfiguration : IEntityTypeConfiguration<TrackTechnology>
{
    public void Configure(EntityTypeBuilder<TrackTechnology> builder)
    {
        builder.HasKey(tt => new { tt.TrackId, tt.TechnologyId });
    }
}

public class FreelancerTechnologyConfiguration : IEntityTypeConfiguration<FreelancerTechnology>
{
    public void Configure(EntityTypeBuilder<FreelancerTechnology> builder)
    {
        builder.HasKey(ft => new { ft.FreelancerId, ft.TechnologyId });
    }
}

public class FreelancerProjectConfiguration : IEntityTypeConfiguration<FreelancerProject>
{
    public void Configure(EntityTypeBuilder<FreelancerProject> builder)
    {
        builder.HasKey(ft => new { ft.FreelancerId, ft.ProjectId });
    }
}

public class FreelancerTaskConfiguration : IEntityTypeConfiguration<FreelancerTask>
{
    public void Configure(EntityTypeBuilder<FreelancerTask> builder)
    {
        builder.HasKey(ft => new { ft.FreelancerId, ft.TaskId });
    }
}