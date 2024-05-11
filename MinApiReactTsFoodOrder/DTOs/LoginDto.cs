using System.ComponentModel.DataAnnotations;

namespace MinApiReactTsFoodOrder.DTOs;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}