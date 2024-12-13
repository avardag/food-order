namespace MinApiReactTsFoodOrder.DTOs;

public class FoodDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string CategoryName { get; set; } = string.Empty; // Return category name
    public double Price { get; set; }
    public List<string>? Origins { get; set; }
    public decimal? Stars { get; set; }
    public List<string> TagNames { get; set; } = new List<string>(); // Return tag names
    public string ImageUrl { get; set; } = string.Empty;
}