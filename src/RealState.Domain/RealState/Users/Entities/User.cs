using RealState.Domain.Abstractions.Entities;

namespace RealState.Domain.RealState.Users.Entities;

public sealed class User : AuditEntity
{
    public string Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public string PasswordSalt { get; private set; } = default!;
    public string Role { get; private set; } = default!;

    public User(string email, string passwordHash, string passwordSalt, string role)
    {
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Role = role;
    }

    public void SetPassword(string passwordHash, string passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public void SetRole(string role) => Role = role;
    public void Activate() => Active();
    public void Deactivate() => InActive();
}