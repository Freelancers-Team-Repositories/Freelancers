using Freelancers.Core.Entities;
using Freelancers.Shared.Abstraction.Const;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Repository.Persistence.EntitiesConfigurations;
public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        // Default Data

        builder.HasData([
            new ApplicationRole{
            Id = DefaultRoles.FreelancerRoleId,
            Name = DefaultRoles.Freelancer,
            NormalizedName = DefaultRoles.Freelancer.ToUpper(),
            ConcurrencyStamp = DefaultRoles.FreelancerRoleConcurrencyStamp,
        },

        new ApplicationRole{
            Id = DefaultRoles.CustomerRoleId,
            Name = DefaultRoles.Customer,
            NormalizedName = DefaultRoles.Customer.ToUpper(),
            ConcurrencyStamp = DefaultRoles.CustomerRoleConcurrencyStamp,
            IsDefault = true,
        }
        ]);
    }
}