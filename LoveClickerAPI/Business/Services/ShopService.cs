using LoveClickerAPI.Business.Interfaces;
using AutoMapper;
using LoveClickerAPI.Contract.Dto;
using LoveClickerAPI.Persistence.Interfaces;
using LoveClickerAPI.Persistence.Models;
namespace LoveClickerAPI.Business.Services
{
  public class ShopService : IShopService
  {
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    public ShopService(IShopRepository shopRepository, IMapper mapper)
    {
      _shopRepository = shopRepository;
      _mapper = mapper;
    }

    public async Task<ShopItemDto> AddShopItem(ShopItemDto item)
    {
      ShopItem itemToAdd = _mapper.Map<ShopItem>(item);
      ShopItem createdItem = await _shopRepository.AddShopItem(itemToAdd);
      return _mapper.Map<ShopItemDto>(createdItem);
    }

    public async Task<ShopItemDto?> GetShopItem(Guid id)
    {
      ShopItem? item = await _shopRepository.GetShopItem(id);
      return item == null ? null : _mapper.Map<ShopItemDto>(item);
    }

    public async Task<List<ShopItemDto>> GetShopItems()
    {
      return _mapper.Map<List<ShopItemDto>>(await _shopRepository.GetShopItems());
    }

  }
}