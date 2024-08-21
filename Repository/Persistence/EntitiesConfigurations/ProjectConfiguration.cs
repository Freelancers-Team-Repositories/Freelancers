
using Freelancers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Repository.Persistence.EntitiesConfigurations;
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(x => x.Title)
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.Summary)
            .HasMaxLength(500);

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(200);

        builder.Property(x => x.ProjectUrl)
            .HasMaxLength(200);

        builder.Property(x => x.VideoUrl)
            .HasMaxLength(200);

    }
}
