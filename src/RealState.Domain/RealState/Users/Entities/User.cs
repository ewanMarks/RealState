using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Users.Entities;

/// <summary>
/// Entidad de dominio que representa un usuario del sistema.
/// </summary>
public sealed class User : AuditEntity
{
    public string Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public string PasswordSalt { get; private set; } = default!;
    public string Role { get; private set; } = default!;

    /// <summary>
    /// Constructor de la entidad <see cref="User"/>.
    /// </summary>
    /// <param name="email">Correo electrónico del usuario.</param>
    /// <param name="passwordHash">Hash de la contraseña.</param>
    /// <param name="passwordSalt">Salt utilizado en el hash.</param>
    /// <param name="role">Rol asignado al usuario.</param>
    public User(string email, string passwordHash, string passwordSalt, string role)
    {
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Role = role;
    }

    /// <summary>
    /// Actualiza la contraseña del usuario estableciendo un nuevo hash y salt.
    /// </summary>
    /// <param name="passwordHash">Nuevo hash de la contraseña.</param>
    /// <param name="passwordSalt">Nuevo salt utilizado en el hash.</param>
    public void SetPassword(string passwordHash, string passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    /// <summary>
    /// Cambia el rol asignado al usuario.
    /// </summary>
    public void SetRole(string role) => Role = role;

    /// <summary>
    /// Marca al usuario como activo.
    /// </summary>
    public void Activate() => Active();

    /// <summary>
    /// Marca al usuario como inactivo (soft delete).
    /// </summary>
    public void Deactivate() => InActive();
}