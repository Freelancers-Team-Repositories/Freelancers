namespace Freelancers.Api.Authentication;

public interface IJwtProvider
{
	(string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles);
}
