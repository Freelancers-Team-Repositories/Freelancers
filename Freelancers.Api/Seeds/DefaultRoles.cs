using Freelancers.Api.Contracts.Const;
using Microsoft.AspNetCore.Identity;

namespace Freelancers.Api.Seeds;

public class DefaultRoles
{
	public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
	{
		if (!roleManager.Roles.Any())
		{
			await roleManager.CreateAsync(new IdentityRole() { Name = AppRoles.Freelancer });
			await roleManager.CreateAsync(new IdentityRole() { Name = AppRoles.Customer });
		}
	}
}
