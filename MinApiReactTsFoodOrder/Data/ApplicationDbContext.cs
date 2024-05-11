using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
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