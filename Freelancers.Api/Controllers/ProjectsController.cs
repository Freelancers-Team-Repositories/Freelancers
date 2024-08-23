using Freelancers.Api.Extensions;
using Freelancers.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Freelancers.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController(IProjectService _projectService) : ControllerBase
{

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok();
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _projectService.Get(id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

}