using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealState.Application.Common.Security;
using RealState.Infrastructure.Security.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealState.Infrastructure.Security;

/// <summary>
/// Servicio encargado de generar tokens JWT para autenticación.
/// </summary>
public sealed class JwtTokenService : IJwtTokenService
{
    private readonly JwtOptions _options;
    private readonly byte[] _key;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="JwtTokenService"/> con las opciones configuradas.
    /// </summary>
    public JwtTokenService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
        _key = Encoding.UTF8.GetBytes(_options.Key);
    }

    /// <summary>
    /// Genera un token JWT con los claims estándar para un usuario.
    /// </summary>
    public (string AccessToken, DateTime ExpiresAtUtc) Generate(Guid userId, string email, string role)
    {
        var now = DateTime.UtcNow;
        var expires = now.AddMinutes(_options.ExpiresMinutes);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(now).ToString(), ClaimValueTypes.Integer64),
        };

        var creds = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: now,
            expires: expires,
            signingCredentials: creds
        );

        string jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return (jwt, expires);
    }
}
