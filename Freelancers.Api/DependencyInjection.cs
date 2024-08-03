using Freelancers.Api.Entities;
using Freelancers.Api.Persistence;
using Freelancers.Api.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Freelancers.Api;

public static class DependencyInjection
{
	public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddControllers();
		services.AddSwaggerConfig();

		services.AddDbConnection(configuration);

		services
			.AddAuthConfig()
			.AddMapsterConfig()
			.AddFreelancersServices();


		return services;
	}


	private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		return services;
	}

	private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

		return services;
	}

	private static IServiceCollection AddFreelancersServices(this IServiceCollection services)
	{
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<IProjectService, ProjectService>();

		return services;
	}

	private static IServiceCollection AddAuthConfig(this IServiceCollection services)
	{
		services.AddIdentity<ApplicationUser, IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>();

		return services;
	}

	private static IServiceCollection AddMapsterConfig(this IServiceCollection services)
	{
		var mappingConfig = TypeAdapterConfig.GlobalSettings;
		mappingConfig.Scan(Assembly.GetExecutingAssembly());

		services.AddSingleton<IMapper>(new Mapper(mappingConfig));

		return services;
	}

}
