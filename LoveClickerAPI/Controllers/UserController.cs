using LoveClickerAPI.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LoveClickerAPI.Contract.Dto;

namespace LoveClickerAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController(IUserService userSvc) : ControllerBase
  {
    private readonly IUserService _userSvc = userSvc;
    [HttpGet("GetUser/{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
      UserDto? user = await _userSvc.GetUser(id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserForRegistrationDto user)
    {
      UserDto? registeredUser = await _userSvc.Register(user);

      if (registeredUser == null)
      {
        return BadRequest();
      }

      return Ok(registeredUser);
    }

    [HttpPost("Authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequestDto authenticateRequest)
    {
      bool success = await _userSvc.Authenticate(authenticateRequest);

      if (!success)
      {
        return Unauthorized();
      }

      return Ok(success);
    }
  }
}