
namespace LoveClickerAPI.Contract.Dto
{
  public class UserDto
  {
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<UserItemDto> Inventory { get; set; } = null!;
    public double Balance { get; set; }
  }
}