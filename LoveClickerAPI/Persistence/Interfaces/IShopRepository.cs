
using LoveClickerAPI.Persistence.Models;
namespace LoveClickerAPI.Persistence.Interfaces
{
  public interface IShopRepository
  {
    Task<List<ShopItem>> GetShopItems();
    Task<ShopItem?> GetShopItem(Guid id);
    Task<ShopItem> AddShopItem(ShopItem itemToAdd);
  }
}