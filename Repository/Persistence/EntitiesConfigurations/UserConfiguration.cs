using Freelancers.Core.Entities;
using Freelancers.Shared.Abstraction.Const;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelancers.Repository.Persistence.EntitiesConfigurations;
public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.FirstName)
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasMaxLength(100);

        // Default Data
        var passwordHasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(new ApplicationUser()
        {
            Id = DefaultUsers.FreelancerId,
            FirstName = "Freelancer",
            LastName = "Freelancer",
            UserName = DefaultUsers.FreelancerEmail,
            NormalizedUserName = DefaultUsers.FreelancerEmail.ToUpper(),
            Email = DefaultUsers.FreelancerEmail,
            NormalizedEmail = DefaultUsers.FreelancerEmail.ToUpper(),
            SecurityStamp = DefaultUsers.FreelancerSecurityStamp,
            ConcurrencyStamp = DefaultUsers.FreelancerConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = passwordHasher.HashPassword(null!, DefaultUsers.FreelancerPassword)
        });
    }
}