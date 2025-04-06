using AutoMapper;
using LoveClickerAPI.Contract.Dto;
using LoveClickerAPI.Persistence.Models;
namespace LoveClickerAPI.Contract
{
  public class ShopItemProfile : Profile
  {
    public ShopItemProfile()
    {
      CreateMap<User, UserDto>().ForMember(d => d.Inventory, o => o.MapFrom(s => s.Inventory.UserItems));
      CreateMap<UserDto, User>();

      CreateMap<UserItem, UserItemDto>();
      CreateMap<UserItemDto, UserItem>();

      CreateMap<ShopItem, ShopItemDto>();
      CreateMap<ShopItemDto, ShopItem>();
    }
  }
}