namespace LoveClickerAPI.Contract.Dto
{
  public class AuthenticateRequestDto
  {
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
  }
}