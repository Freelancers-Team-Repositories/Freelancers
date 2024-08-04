using Freelancers.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Api.Persistence.EntitiesConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{
		builder.Property(x => x.FirstName)
			.HasMaxLength(100);

		builder.Property(x => x.LastName)
			.HasMaxLength(100);
	}
}
