namespace LoveClickerAPI.Business.Interfaces
{
  public interface IPasswordHasher
  {
    public string HashPasswordWithSaltAndPepper(string password, string salt);
    public string GenerateSalt();
  }
}