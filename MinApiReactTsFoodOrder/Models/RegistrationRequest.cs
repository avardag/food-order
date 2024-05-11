using System.ComponentModel.DataAnnotations;
using MinApiReactTsFoodOrder.Enums;

namespace MinApiReactTsFoodOrder.Models;

public class RegistrationRequest
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
    // if a role isn’t explicitly specified we will default to the user role.
    public Role Role { get; set; }
}