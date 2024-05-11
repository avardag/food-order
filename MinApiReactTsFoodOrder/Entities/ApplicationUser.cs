using Microsoft.AspNetCore.Identity;
using MinApiReactTsFoodOrder.Enums;

namespace MinApiReactTsFoodOrder.Entities;

public class ApplicationUser : IdentityUser
{
    public Role Role { get; set; }
}