
using Microsoft.EntityFrameworkCore;
using LoveClickerAPI.Persistence.Models;
using LoveClickerAPI.Persistence.Interfaces;
namespace LoveClickerAPI.Persistence.Repositories
{
  public class ShopRepository : IShopRepository
  {
    private readonly LoveClickerAPIContext _context;
    public ShopRepository(LoveClickerAPIContext context)
    {
      _context = context;
    }
    public async Task<ShopItem> AddShopItem(ShopItem itemToAdd)
    {
      _context.Add(itemToAdd);
      await _context.SaveChangesAsync();
      return itemToAdd;
    }

    public async Task<ShopItem?> GetShopItem(Guid id)
    {
      return await _context.ShopItems.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<ShopItem>> GetShopItems()
    {
      return await _context.ShopItems.ToListAsync();

    }
  }
}