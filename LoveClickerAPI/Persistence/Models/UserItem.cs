namespace LoveClickerAPI.Persistence.Models
{
  public class UserItem
  {
    public Guid Id { get; set; }
    public Guid ShopItemId { get; set; }
    public ShopItem ShopItem { get; set; } = null!;
    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; set; } = null!;
  }
}