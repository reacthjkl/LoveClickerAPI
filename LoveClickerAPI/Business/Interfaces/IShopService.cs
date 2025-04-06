using LoveClickerAPI.Contract.Dto;
namespace LoveClickerAPI.Business.Interfaces
{
  public interface IShopService
  {
    Task<List<ShopItemDto>> GetShopItems();
    Task<ShopItemDto?> GetShopItem(Guid id);
    Task<ShopItemDto> AddShopItem(ShopItemDto item);
  }
}