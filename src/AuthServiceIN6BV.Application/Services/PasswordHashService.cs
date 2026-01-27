using AuthServiceIN6BV.Application.Interfaces;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace AuthServiceIN6BV.Application.Services;

public class PasswordHashService : IPasswordHashService
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 2;
    private const int Memory = 102400;
    private const int Parallelism = 8;

    public string HashPassword(string password)
    {
        var salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = Parallelism,
            Iterations = Iterations,
            MemorySize = Memory
        };

        var hash = argon2.GetBytes(HashSize);

        var saltBase64 = Convert.ToBase64String(salt);
        var hashBase64 = Convert.ToBase64String(hash);

        return $"$argon2id$v=19$m={Memory},t={Iterations},p={Parallelism}${saltBase64}${hashBase64}";
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        try
        {
            Console.WriteLine($"[DEBUG] Verifying password for hash: {hashedPassword.Substring(0, Math.Min(50, hashedPassword.Length))}...");
            
            if(hashedPassword.StartsWith("$argon2id$"))
            {
                Console.WriteLine("[DEBUG] Using Argon2 standard format verification");
                var result = VerifyArgon2StandardFormat(password, hashedPassword);
                Console.WriteLine($"[DEBUG] Verification result: {result}");
                return result;
            }
            else
            {
                Console.WriteLine("[DEBUG] Using legacy format verification");
                return VerifyLegacyFormat(password, hashedPassword);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"[DEBUG] Exception in VerifyPassword: {ex.Message}");
            return false;
        }
    }

    private bool VerifyArgon25tandardFormat(string password, string hashedPassword)
    {
        
    }

}