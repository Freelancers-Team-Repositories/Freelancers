using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace Freelancers.Api.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
	IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{


	protected override void OnModelCreating(ModelBuilder builder)
	{

		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


		base.OnModelCreating(builder);
	}
}
