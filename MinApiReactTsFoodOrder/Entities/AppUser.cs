using Microsoft.AspNetCore.Identity;
using MinApiReactTsFoodOrder.Enums;

namespace MinApiReactTsFoodOrder.Entities;

public class AppUser : IdentityUser
{
    public Role Role { get; set; }
}