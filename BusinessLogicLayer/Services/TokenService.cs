
using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThreeTierArchitecture.Domain.Entities;

namespace BusinessLogicLayer.Services;

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;

    public TokenService(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }
    public string GenerateJwtToken(ApplicationUser user)
    {
        //var jwt = _config.GetSection("JwtSettings");
        ArgumentNullException.ThrowIfNull(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Role,user.Role.ToString())
        };
        var key = new SymmetricSecurityKey(
           Encoding.UTF8.GetBytes(_jwtSettings.Key)
       );
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                    signingCredentials: credentials
                );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
