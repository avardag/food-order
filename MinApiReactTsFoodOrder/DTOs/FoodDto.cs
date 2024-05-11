namespace MinApiReactTsFoodOrder.DTOs;

public class FoodDto
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
    // public Tag[] Tags { get; set; }
    public string[] Tags { get; set; }
}