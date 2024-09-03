using Freelancers.Api.Extensions;
using Freelancers.Core.Contracts.Tracks;

namespace Freelancers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TracksController(ITrackService trackService) : ControllerBase
{
    private readonly ITrackService _trackService = trackService;


    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _trackService.GetAllAsync();

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _trackService.GetAsync(id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpPost("")]
    public async Task<IActionResult> Add(CreateTrackRequest request)
    {
        var result = await _trackService.CreateAsync(request);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTrackRequest request)
    {
        var result = await _trackService.UpdateAsync(id, request);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _trackService.DeleteAsync(id);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

}
