namespace LoveClickerAPI.Persistence.Models
{
  public class ShopItem
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
  }
}