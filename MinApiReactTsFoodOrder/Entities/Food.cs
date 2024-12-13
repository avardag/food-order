namespace MinApiReactTsFoodOrder.Entities;
/*
 * {
     id: 8,
     name: "Tofu salad",
     price: 10,
     cookTime: "10-15",
     favorite: false,
     origins: ["japan", "asia"],
     stars: 3.5,
     imageUrl: "anh-nguyen-kcA-c3f_3FE-unsplash.jpg",
     tags: ["Vegan", "Lunch"],
   },
 */
public class Food
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } 
    public double Price { get; set; }
    public bool? Favorite { get; set; }
    public List<string>? Origins { get; set; }
    public decimal? Stars { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<Tag> Tags { get; set; } = new List<Tag>();
    public bool IsDeleted { get; set; } = false;
}