using System.ComponentModel.DataAnnotations;

namespace MinApiReactTsFoodOrder.DTOs;

public class RegisterDto
{
    [Required]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}