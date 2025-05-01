using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Server.Helpers;

public class JwtTokenHelper
{
    private readonly IConfiguration _configuration;

    public JwtTokenHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(int userId, string userName)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, userName)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpireMinutes"]!)),
            Issuer = _configuration["Jwt:Issuer"]!,
            Audience = _configuration["Jwt:Audience"]!,
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}