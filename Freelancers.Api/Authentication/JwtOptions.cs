using System.ComponentModel.DataAnnotations;

namespace Freelancers.Api.Authentication;

public class JwtOptions
{
	public static string SectionName = "Jwt";

	[Required]
	public string Issuer { get; set; } = string.Empty;

	[Required]
	public string Audience { get; set; } = string.Empty;

	[Required]
	public string Key { get; set; } = string.Empty;

	[Range(1, int.MaxValue)]
	public int ExpiryHours { get; set; }
}
