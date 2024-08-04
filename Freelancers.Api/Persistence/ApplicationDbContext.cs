using Freelancers.Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Freelancers.Api.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{


	protected override void OnModelCreating(ModelBuilder builder)
	{

		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


		base.OnModelCreating(builder);
	}
}
