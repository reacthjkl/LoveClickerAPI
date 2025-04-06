namespace LoveClickerAPI.Persistence.Models
{
  public class UserSecret
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Salt { get; set; } = null!;
  }
}