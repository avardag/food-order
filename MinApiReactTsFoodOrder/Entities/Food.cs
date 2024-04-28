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
    public string Name { get; set; }
    public int Price { get; set; }
    public string CookTime { get; set; }
    public bool Favorite { get; set; }
    public string[] Origins { get; set; }
    public double Stars { get; set; }
    public string ImageUrl { get; set; }
    // public Tag[] Tags { get; set; }
    public string[] Tags { get; set; }
}