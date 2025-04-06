using System;
using System.Security.Cryptography;
using System.Text;
using LoveClickerAPI.Business.Interfaces;

namespace LoveClickerAPI.Business.Helpers
{
  public class PasswordHasher : IPasswordHasher
  {
    private readonly IConfiguration _configuration;
    private readonly string _pepper;

    public PasswordHasher(IConfiguration configuration)
    {
      _configuration = configuration;
      _pepper = _configuration.GetValue<string>("PasswordPepper") ?? throw new Exception("No pepper found in configuration!");
    }

    public string HashPasswordWithSaltAndPepper(string password, string salt)
    {
      // Combine password, salt, and pepper
      string combined = password + salt + _pepper;

      using (SHA256 sha256 = SHA256.Create())
      {
        // Compute hash of combined string
        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));

        // Convert hash bytes to a hexadecimal string
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
      }
    }

    public string GenerateSalt()
    {
      using (var rng = RandomNumberGenerator.Create())
      {
        byte[] salt = new byte[16]; // 16 bytes = 128 bits
        rng.GetBytes(salt);
        return Convert.ToBase64String(salt);
      }
    }
  }
}