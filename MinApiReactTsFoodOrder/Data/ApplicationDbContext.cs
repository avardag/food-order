using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Entities;
using MinApiReactTsFoodOrder.Enums;

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
        
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            },
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
        
        // // Seed AspNetUsers table with default admin user
        // var hasher = new PasswordHasher<AppUser>();
        //
        // var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminEmail"];
        // var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminPassword"];
        //
        // modelBuilder.Entity<AppUser>().HasData(
        //     new AppUser
        //     {
        //         Id = "80c8b6b1-e2b6-45e8-b044-8f2178a90111", // primary key
        //         UserName = "admin",
        //         NormalizedUserName = adminEmail.ToUpper(),
        //         PasswordHash = hasher.HashPassword(null, adminPassword),
        //         Email = adminEmail,
        //         NormalizedEmail = adminEmail.ToUpper(),
        //         Role = Role.Admin
        //     }
        // );
    }
}