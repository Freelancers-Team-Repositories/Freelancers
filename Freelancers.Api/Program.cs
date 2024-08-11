using Freelancers.Api;
using Freelancers.Api.Seeds;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDependencies(builder.Configuration);



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();


#region Seed Data
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using var scope = scopeFactory.CreateScope();

var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

await DefaultRoles.SeedAsync(roleManager);
await DefaultUsers.SeedFreelancerAsync(userManager);
#endregion

app.UseExceptionHandler();

app.MapControllers();

app.Run();
