using LoveClickerAPI.Contract.Dto;

namespace LoveClickerAPI.Business.Interfaces
{
  public interface IUserService
  {
    Task<bool> Authenticate(AuthenticateRequestDto authenticateRequest);
    Task<UserDto?> GetUser(Guid id);
    Task<UserDto?> Register(UserForRegistrationDto user);
  }
}