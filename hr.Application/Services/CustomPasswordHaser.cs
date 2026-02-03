using System.Security.Cryptography;
using Application.Interfaces.Password;

namespace Application.Services;

public class CustomPasswordHaser : ICustomPasswordHasher
{
    private const int  SaltSize = 16;
    private readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;
    private const int Iterations = 100000;

    public string HashedPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hashed = Rfc2898DeriveBytes.Pbkdf2(password, salt,Iterations,Algorithm, 256 / 8);
        return Convert.ToBase64String(hashed);
    }
    
}