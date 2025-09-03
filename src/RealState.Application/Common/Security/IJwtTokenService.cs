namespace RealState.Application.Common.Security;

public interface IJwtTokenService
{
    /// <summary>
    /// Genera un JWT firmado (HS256) y devuelve el token y su fecha de expiración (UTC).
    /// </summary>
    (string AccessToken, DateTime ExpiresAtUtc) Generate(Guid userId, string email, string role);
}
