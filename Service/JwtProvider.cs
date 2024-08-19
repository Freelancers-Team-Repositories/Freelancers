using Freelancers.Core.Entities;
using Freelancers.Core.Interfaces;
using Freelancers.Shared.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Freelancers.Service;
public class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public (string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles)
    {
        Claim[] claims = [
            new(JwtRegisteredClaimNames.Sub,user.Id),
        new(JwtRegisteredClaimNames.Email,user.Email!),
        new(JwtRegisteredClaimNames.GivenName,user.FirstName!),
        new(JwtRegisteredClaimNames.FamilyName,user.LastName!),
        new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        new (nameof(roles)  , JsonSerializer.Serialize(roles),JsonClaimValueTypes.JsonArray)
        ];


        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var expiresIn = _jwtOptions.ExpiryHours;
        var expirationDate = DateTime.UtcNow.AddHours(expiresIn);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: expirationDate,
            signingCredentials: signingCredentials
        );


        return (token: new JwtSecurityTokenHandler().WriteToken(token), expiresIn);
    }
}