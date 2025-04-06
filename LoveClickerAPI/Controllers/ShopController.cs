using LoveClickerAPI.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LoveClickerAPI.Contract.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
namespace LoveClickerAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ShopController(IShopService shopSvc) : ControllerBase
  {
    private readonly IShopService _shopSvc = shopSvc;

    [HttpGet("GetShopItem/{id}")]
    public async Task<IActionResult> GetShopItem(Guid id)
    {
      ShopItemDto? item = await _shopSvc.GetShopItem(id);
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
    }

    [HttpGet("GetShopItems")]
    public async Task<IActionResult> GetShopItems()
    {
      var items = await _shopSvc.GetShopItems();
      if (items.Count == 0)
      {
        return NotFound();
      }
      return Ok(items);
    }

    [HttpPost("AddShopItem")]
    public async Task<IActionResult> AddShopItem(ShopItemDto item)
    {
      ShopItemDto createdItem = await _shopSvc.AddShopItem(item);

      return Ok(createdItem);
    }
  }
}