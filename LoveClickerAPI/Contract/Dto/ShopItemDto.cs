namespace LoveClickerAPI.Contract.Dto
{
  public class ShopItemDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
  }
}