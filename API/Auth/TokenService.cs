using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

public class TokenService
{
    private readonly IConfiguration _config;

    public TokenService (IConfiguration config)
    {
        _config = config;
    }
    
    public string GenerateToken(ApplicationUser user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            // include user id and username
            new Claim(ClaimTypes.NameIdentifier, user?.Id ?? string.Empty),
            new Claim(ClaimTypes.Name, user?.UserName ?? string.Empty)
        };

        if (roles != null)
        {
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
        }

        var jwtKey = _config["Jwt:Key"] ?? "your-super-secret-key-that-is-at-least-32-characters-long-for-hs256";
        var jwtIssuer = _config["Jwt:Issuer"] ?? "BookingSystemAPI";
        var jwtAudience = _config["Jwt:Audience"] ?? "BookingSystemClient";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}