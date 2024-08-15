using Freelancers.Api;
using Freelancers.Api.Seeds;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDependencies(builder.Configuration);

builder.Host.UseSerilog((context, configuration) =>
{
	configuration.ReadFrom.Configuration(context.Configuration);
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors();


#region Seed Data
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using var scope = scopeFactory.CreateScope();

var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

await DefaultRoles.SeedAsync(roleManager);
await DefaultUsers.SeedFreelancerAsync(userManager);
#endregion

#region Hangfire configurations
app.UseHangfireDashboard("/jobs", new DashboardOptions()
{
	Authorization =
	[
		new HangfireCustomBasicAuthenticationFilter
		{
			User  = app.Configuration.GetValue<string>("HangfireSettings:Username"),
			Pass  = app.Configuration.GetValue<string>("HangfireSettings:Password")
		}
	],
	DashboardTitle = "Freelancers Dashboard",

});
#endregion


app.UseExceptionHandler();

app.UseSerilogRequestLogging();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
