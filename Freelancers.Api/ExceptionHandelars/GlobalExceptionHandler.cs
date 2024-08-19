using Microsoft.AspNetCore.Diagnostics;

namespace Freelancers.Api.Errors;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
	private readonly ILogger<GlobalExceptionHandler> _logger = logger;

	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
	{
		_logger.LogError(exception, "something went wrong {Message}", exception.Message);

		var problemDetails = new ProblemDetails
		{
			Status = StatusCodes.Status500InternalServerError,
			Title = "internal Server Error",
			Type = "https://datatracker.ietf.org/doc/html/rfc7231#page-63",
		};

		httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

		await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);

		return true;
	}
}
