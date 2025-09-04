using RealState.Application.Common.Security;
using System.Security.Cryptography;

namespace RealState.Infrastructure.Security;

/// <summary>
/// Implementación de <see cref="IPasswordHasher"/> utilizando el algoritmo PBKDF2 con SHA-256.
/// </summary>
public sealed class PasswordHasherPbkdf2 : IPasswordHasher
{
    private const int Iterations = 100_000;
    private const int SaltSize = 16;
    private const int HashSize = 32;

    /// <summary>
    /// Genera un hash seguro para la contraseña especificada utilizando PBKDF2 con un salt aleatorio.
    /// </summary>
    public (string Hash, string Salt) Hash(string password)
    {
        byte[] saltBytes = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(
            password: password,
            salt: saltBytes,
            iterations: Iterations,
            hashAlgorithm: HashAlgorithmName.SHA256,
            outputLength: HashSize);

        return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
    }

    /// <summary>
    /// Verifica si la contraseña proporcionada corresponde al hash y salt almacenados.
    /// </summary>
    public bool Verify(string password, string hash, string salt)
    {
        try
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] expected = Convert.FromBase64String(hash);

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
                password: password,
                salt: saltBytes,
                iterations: Iterations,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: expected.Length);

            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
        catch
        {
            return false;
        }
    }
}