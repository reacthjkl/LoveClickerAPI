using LoveClickerAPI.Persistence.Interfaces;
using LoveClickerAPI.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using LoveClickerAPI.Business.Helpers;
using LoveClickerAPI.Business.Interfaces;

namespace LoveClickerAPI.Persistence.Repositories
{
  public class UserRepository(LoveClickerAPIContext context, IPasswordHasher passwordHasher) : IUserRepository
  {
    private readonly LoveClickerAPIContext _context = context;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<User> AddUser(User userToAdd)
    {
      _context.Users.Add(userToAdd);
      await _context.SaveChangesAsync();
      return userToAdd;
    }

    public async Task<User?> GetUser(Guid id)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public Task<User?> GetUserByUsername(string username)
    {
      return _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<bool> VerifyPassword(Guid id, string password)
    {
      UserSecret? userSecret = await _context.UserSecrets.FirstOrDefaultAsync(s => s.UserId == id);

      if (userSecret == null) return false;

      string hashedPassword = _passwordHasher.HashPasswordWithSaltAndPepper(password, userSecret.Salt);

      return hashedPassword == userSecret.Password;
    }
  }
}