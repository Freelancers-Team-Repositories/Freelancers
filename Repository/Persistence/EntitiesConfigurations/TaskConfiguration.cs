using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Repository.Persistence.EntitiesConfigurations;

public class TaskConfiguration : IEntityTypeConfiguration<Core.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Task> builder)
    {
        builder.Property(x => x.Description)
            .HasMaxLength(1000);


    }
}
