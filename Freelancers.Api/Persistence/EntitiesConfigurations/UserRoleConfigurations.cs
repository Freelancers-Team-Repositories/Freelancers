using Freelancers.Api.Abstraction.Const;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Api.Persistence.EntitiesConfigurations;

public class UserRoleConfigurations : IEntityTypeConfiguration<IdentityUserRole<string>>
{

	public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
	{
		builder.HasData(new IdentityUserRole<string>
		{
			UserId = DefaultUsers.FreelancerId,
			RoleId = DefaultRoles.FreelancerRoleId
		});
	}
}