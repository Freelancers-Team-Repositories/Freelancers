using Freelancers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Repository.Persistence.EntitiesConfigurations;

public class SubImageConfiguration : IEntityTypeConfiguration<SubImage>
{
    public void Configure(EntityTypeBuilder<SubImage> builder)
    {
        builder.Property(x => x.Url)
            .HasMaxLength(200);
    }
}
