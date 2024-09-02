using Freelancers.Api.Extensions;
using Freelancers.Core.Contracts.Users;
using Freelancers.Shared.Abstraction.Const;
using Microsoft.AspNetCore.Authorization;

namespace Freelancers.Api.Controllers;


[Authorize(Roles = DefaultRoles.Admin)]
[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService _userService) : ControllerBase
{

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetAllAsync();

        return Ok(result.Value);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _userService.GetAsync(id);

        return Ok(result.Value);
    }


    [HttpPost("")]
    public async Task<IActionResult> Add(CreateUserRequest request)
    {
        var result = await _userService.AddAsync(request);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromForm] UpdateUserRequest request)
    {
        var result = await _userService.UpdateAsync(id, request);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }


    [HttpPut("toggle-status/{id}")]
    public async Task<IActionResult> ToggleStatus(string id)
    {
        var result = await _userService.ToggleStatusAsync(id);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }





}
