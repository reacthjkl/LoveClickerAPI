namespace LoveClickerAPI.Contract.Dto
{
  public class UserItemDto
  {
    public Guid Id { get; set; }
    public ShopItemDto ShopItem { get; set; } = null!;
  }
}