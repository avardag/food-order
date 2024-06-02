using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.DTOs;

public class NewFoodDto
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
    public TagDto[] Tags { get; set; }
    public List<string> Origins { get; set; }
    public double Stars { get; set; }
    public string CookTime { get; set; } = string.Empty;
}
