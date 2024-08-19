using Freelancers.Core.Entities;

namespace Freelancers.Core.Interfaces;
public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles);
}