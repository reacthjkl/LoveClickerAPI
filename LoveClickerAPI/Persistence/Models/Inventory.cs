namespace LoveClickerAPI.Persistence.Models
{
  public class Inventory
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid User { get; set; }
    public List<UserItem> UserItems { get; set; } = [];
  }
}