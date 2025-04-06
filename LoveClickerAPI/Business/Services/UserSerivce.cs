using AutoMapper;
using LoveClickerAPI.Business.Interfaces;
using LoveClickerAPI.Contract.Dto;
using LoveClickerAPI.Persistence.Interfaces;
using LoveClickerAPI.Persistence.Models;
using LoveClickerAPI.Business.Helpers;

namespace LoveClickerAPI.Business.Services
{
  public class UserService(IMapper mapper, IUserRepository userRepository, IPasswordHasher passwordHasher) : IUserService
  {
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;



    public async Task<UserDto?> GetUser(Guid id)
    {
      User? user = await _userRepository.GetUser(id);
      return user == null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> Register(UserForRegistrationDto user)
    {
      string salt = _passwordHasher.GenerateSalt();
      string hashedPassword = _passwordHasher.HashPasswordWithSaltAndPepper(user.Password, salt);

      User userToAdd = new User
      {
        Id = Guid.NewGuid(),
        Balance = 0,
        Email = user.Email,
        Username = user.Username,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Inventory = new Inventory
        {
          Id = Guid.NewGuid(),
          UserItems = []
        },
        UserSecret = new UserSecret
        {
          Password = hashedPassword,
          Salt = salt,
        }
      };

      User addedUser = await _userRepository.AddUser(userToAdd);
      return addedUser == null ? null : _mapper.Map<UserDto>(addedUser);
    }
    public async Task<bool> Authenticate(AuthenticateRequestDto authenticateRequest)
    {
      User? user = await _userRepository.GetUserByUsername(authenticateRequest.Username);

      if (user == null) return false;

      return await _userRepository.VerifyPassword(user.Id, authenticateRequest.Password);
    }
  }
}