using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.Data;

public class ApplicationDbContext : IdentityUserContext<ApplicationUser>
{
    public DbSet<Food> Foods => Set<Food>();
    public DbSet<Tag> Tags => Set<Tag>();


    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}