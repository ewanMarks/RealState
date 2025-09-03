using Microsoft.EntityFrameworkCore;
using RealState.Domain.RealState.Users.Entities;
using RealState.Infrastructure.Persistence.Context;
using System.Security.Cryptography;

namespace RealState.Infrastructure.Seeders.RealState;

public class UserSeeder : ISeeder<RealStateDbContext>
{
    public async Task Seed(RealStateDbContext context)
    {
        if (await context.Users.AnyAsync())
        {
            return;
        }

        const string email = "admin@realstate.com";
        const string password = "RealState$123";
        const string role = "Admin";

        byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
        byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(
            password: password,
            salt: saltBytes,
            iterations: 100_000,
            hashAlgorithm: HashAlgorithmName.SHA256,
            outputLength: 32);

        string salt = Convert.ToBase64String(saltBytes);
        string hash = Convert.ToBase64String(hashBytes);

        var admin = new User(
            email: email,
            passwordHash: hash,
            passwordSalt: salt,
            role: role
        );

        context.Users.Add(admin);
    }
}
