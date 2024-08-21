namespace Freelancers.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
// [Authorize]
public class ProjectsController : ControllerBase
{

    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok();
    }

}