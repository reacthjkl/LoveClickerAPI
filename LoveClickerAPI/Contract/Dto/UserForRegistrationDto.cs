namespace LoveClickerAPI.Contract.Dto
{
  public class UserForRegistrationDto
  {
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
  }
}