using MinApiReactTsFoodOrder.Enums;

namespace MinApiReactTsFoodOrder.DTOs;

public class NewUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public Role Role { get; set; }
}

