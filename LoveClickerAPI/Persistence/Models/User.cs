namespace LoveClickerAPI.Persistence.Models
{
  public class User
  {
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Inventory Inventory { get; set; } = null!;
    public double Balance { get; set; }
    public UserSecret UserSecret { get; set; } = null!;
  }
}