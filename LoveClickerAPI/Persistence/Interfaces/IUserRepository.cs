using LoveClickerAPI.Persistence.Models;

namespace LoveClickerAPI.Persistence.Interfaces
{
  public interface IUserRepository
  {
    Task<User> AddUser(User userToAdd);
    Task<User?> GetUser(Guid id);
    Task<User?> GetUserByUsername(string email);
    Task<bool> VerifyPassword(Guid id, string password);
  }
}