using Freelancers.Api.Extensions;
using Freelancers.Core.Contracts.Users;
using Freelancers.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Freelancers.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class AccountController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;


    [HttpGet("")]
    public async Task<IActionResult> Info()
    {
        var result = await _userService.GetProfileAsync(User.GetUserId()!);

        return Ok(result.Value);
    }



    [HttpPut("update-info")]
    public async Task<IActionResult> Info(UpdateProfileRequest request)
    {
        await _userService.UpdateProfileAsync(User.GetUserId()!, request);

        return NoContent();
    }



    [HttpPut("change-password")]
    public async Task<IActionResult> Info(ChangePasswordRequest request)
    {
        var result = await _userService.ChangePasswordAsync(User.GetUserId()!, request);

        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

}

