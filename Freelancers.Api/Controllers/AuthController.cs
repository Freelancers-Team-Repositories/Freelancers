
namespace Freelancers.Api.Controllers;


[Route("[controller]")]
[ApiController]
public class AuthController(UserManager<ApplicationUser> userManager, IAuthService authService, IEmailSender emailSender) : ControllerBase
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly IAuthService _authService = authService;
	private readonly IEmailSender _emailSender = emailSender;


	[HttpPost("SignUp")]
	public async Task<IActionResult> SignUp(SignUpRequest request, CancellationToken cancellationToken)
	{
		var result = await _authService.RegisterAsync(request, cancellationToken);

		return result.IsSuccess ? Ok() : result.ToProblem();
	}


	[HttpPost("Login")]
	public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
	{
		var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

		return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();
	}


	[HttpPost("confirm-email")]
	public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request, CancellationToken cancellationToken)
	{
		var result = await _authService.ConfirmEmailAsync(request);

		return result.IsSuccess ? Ok() : result.ToProblem();
	}


	[HttpPost("resend-confirmation-email")]
	public async Task<IActionResult> ResendConfirmationEmail([FromBody] ResendConfirmationEmailRequest request, CancellationToken cancellationToken)
	{
		var result = await _authService.ResendConfirmationEmailAsync(request);

		return result.IsSuccess ? Ok() : result.ToProblem();
	}

}
