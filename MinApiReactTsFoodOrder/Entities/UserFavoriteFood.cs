namespace MinApiReactTsFoodOrder.Entities;

public class UserFavoriteFood
{
    public string UserId { get; set; } // Foreign key to the User table (e.g., IdentityUser)
    public AppUser User { get; set; }

    public int FoodId { get; set; } // Foreign key to the Food table
    public Food Food { get; set; }
}