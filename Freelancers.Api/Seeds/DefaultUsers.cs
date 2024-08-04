using Freelancers.Api.Contracts.Const;
using Freelancers.Api.Entities;
using Microsoft.AspNetCore.Identity;

namespace Freelancers.Api.Seeds;

public class DefaultUsers
{
	public static async Task SeedFreelancerAsync(UserManager<ApplicationUser> userManager)
	{
		ApplicationUser admin = new()
		{
			FirstName = "Freelancer",
			LastName = "Admin",
			UserName = "Freelancer@gmail.com",
			Email = "Freelancer@gmail.com",
			EmailConfirmed = true,
		};

		var user = await userManager.FindByEmailAsync(admin.Email);

		if (user is null)
		{
			IdentityResult result = await userManager.CreateAsync(admin, "P@ssword123");

			if (result.Succeeded)
				await userManager.AddToRoleAsync(admin, AppRoles.Freelancer);
		}

	}


}
