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
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<UserFavoriteFood> UserFavoriteFoods { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Check if roles are already seeded
        if (!modelBuilder.Model.GetEntityTypes().Any(e => e.Name == typeof(IdentityRole).FullName))
        {
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = Role.Admin.ToString(),
                    NormalizedName = Role.Admin.ToString().ToUpper()
                },
                new IdentityRole
                {
                    Name = Role.User.ToString(),
                    NormalizedName = Role.User.ToString().ToUpper()
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
        
        // Seed AspNetUsers table with default admin user
        var hasher = new PasswordHasher<AppUser>();
        
        var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminEmail"];
        var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminPassword"];
        
        modelBuilder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = "80c8b6b1-e2b6-45e8-b044-8f2178a90111", // primary key
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                PasswordHash = hasher.HashPassword(null, adminPassword),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                Role = Role.Admin,
                FirstName = "Maga",
                LastName = "Bagaev",
                EmailConfirmed = true
            }
        );
        //User Favourite food
        modelBuilder.Entity<UserFavoriteFood>()
            .HasKey(uff => new { uff.UserId, uff.FoodId }); // Composite key

        modelBuilder.Entity<UserFavoriteFood>()
            .HasOne(uff => uff.User)
            .WithMany() // Or WithMany(u => u.FavoriteFoods) if you want a collection on User
            .HasForeignKey(uff => uff.UserId);

        modelBuilder.Entity<UserFavoriteFood>()
            .HasOne(uff => uff.Food)
            .WithMany() // Or WithMany(f => f.UserFavorites) if you want a collection on Food
            .HasForeignKey(uff => uff.FoodId);
        
        // Many-to-many relationship between Food and Tag
        modelBuilder.Entity<Food>()
            .HasMany(f => f.Tags)
            .WithMany(t => t.Foods)
            .UsingEntity(j => j.ToTable("FoodTag")); // Optional: Customize the join table name

        //seed tags
        modelBuilder.Entity<Tag>().HasData(
            new Tag { Id = 9, Name = "Breakfast" },
            new Tag { Id = 10, Name = "Lunch" },
            new Tag { Id = 11, Name = "Dinner" },
            new Tag { Id = 12, Name = "Dessert" },
            new Tag { Id = 13, Name = "Snack" },
            new Tag { Id = 14, Name = "Vegetarian" },
            new Tag { Id = 15, Name = "Vegan" },
            new Tag { Id = 16, Name = "Gluten-Free" },
            new Tag { Id = 17, Name = "Healthy" },
            new Tag { Id = 18, Name = "Low-Carb" },
            new Tag { Id = 19, Name = "Spicy" },
            new Tag { Id = 20, Name = "Comfort Food" }
        );
        // Food-Category relationship
        modelBuilder.Entity<Food>()
            .HasOne(f => f.Category)
            .WithMany() // Or WithMany(c => c.Foods) if you want a collection on Category
            .HasForeignKey(f => f.CategoryId);

        //Seed Categories:
        modelBuilder.Entity<Category>().HasData(
            new Category[] { // Create an array of Category objects
                new Category { Id = 1, Name = "Appetizer" },
                new Category { Id = 2, Name = "Main Course" },
                new Category { Id = 3, Name = "Dessert" },
                new Category { Id = 4, Name = "Salad" },
                new Category { Id = 5, Name = "Soup" }
            }
        );
    }
}
//dotnet ef migrations add AddCategoriesAndFavoriteFood --project MinApiReactTsFoodOrder
//dotnet ef database update --project MinApiReactTsFoodOrder