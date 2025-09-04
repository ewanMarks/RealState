namespace RealState.Infrastructure.Security.Models;

/// <summary>
/// Representa las opciones de configuración para la autenticación mediante JWT (JSON Web Token).
/// </summary>
public sealed class JwtOptions
{
    /// <summary>
    /// Identificador del emisor del token (Issuer).
    /// </summary>
    public string Issuer { get; set; } = "";

    /// <summary>
    /// Identificador de la audiencia válida para el token (Audience).
    /// </summary>
    public string Audience { get; set; } = "";

    /// <summary>
    /// Clave secreta usada para firmar los tokens JWT.
    /// </summary>
    public string Key { get; set; } = "";

    /// <summary>
    /// Tiempo de expiración del token en minutos.
    /// Valor por defecto: 60 minutos.
    /// </summary>
    public int ExpiresMinutes { get; set; } = 60;
}