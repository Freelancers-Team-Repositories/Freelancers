using Microsoft.AspNetCore.Authorization;

namespace Freelancers.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController : ControllerBase
{
	[HttpGet("")]
	public IActionResult Get()
	{
		return Ok("Authorized");
	}

}