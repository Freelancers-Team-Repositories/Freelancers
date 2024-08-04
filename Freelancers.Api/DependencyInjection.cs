using FluentValidation;
using FluentValidation.AspNetCore;
using Freelancers.Api.Authentication;
using Freelancers.Api.Entities;
using Freelancers.Api.Persistence;
using Freelancers.Api.Services;
using Freelancers.Api.Settings;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;


namespace Freelancers.Api;

public static class DependencyInjection
{
	public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddControllers();
		services.AddSwaggerConfig();

		services.AddDbConnectionConfig(configuration);


		services
			.AddAuthConfig(configuration)
			.AddMapsterConfig()
			.AddFluentValidationConfig()
			.AddDefaultCorsConfig()
			.AddFreelancersServices()
			.AddFreelancersOptions(configuration);




		return services;
	}




	private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		return services;
	}
	private static IServiceCollection AddDbConnectionConfig(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

		return services;
	}


	private static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddIdentity<ApplicationUser, IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();

		services.AddSingleton<IJwtProvider, JwtProvider>();

		services.AddOptions<JwtOptions>()
			.Bind(configuration.GetSection(JwtOptions.SectionName))
			.ValidateDataAnnotations()
			.ValidateOnStart();


		var jwtOptions = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(o =>
		{
			o.SaveToken = true;
			o.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,

				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.Key!)),
				ValidIssuer = jwtOptions?.Issuer,
				ValidAudience = jwtOptions?.Audience,
			};

		});

		return services;
	}

	private static IServiceCollection AddMapsterConfig(this IServiceCollection services)
	{
		var mappingConfig = TypeAdapterConfig.GlobalSettings;
		mappingConfig.Scan(Assembly.GetExecutingAssembly());

		services.AddSingleton<IMapper>(new Mapper(mappingConfig));

		return services;
	}

	private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
	{
		services
			.AddFluentValidationAutoValidation()
			.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		return services;
	}

	private static IServiceCollection AddDefaultCorsConfig(this IServiceCollection services)
	{
		services.AddCors(c => c.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

		return services;
	}

	private static IServiceCollection AddFreelancersServices(this IServiceCollection services)
	{
		services.AddScoped<IAuthService, AuthService>();

		services.AddTransient<IEmailSender, EmailSender>();


		return services;
	}

	private static IServiceCollection AddFreelancersOptions(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

		return services;
	}




}
