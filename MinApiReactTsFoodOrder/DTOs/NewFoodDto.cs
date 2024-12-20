using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.DTOs;

public class NewFoodDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public double Price { get; set; }
    public List<string>? Origins { get; set; }
    public decimal? Stars { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<int> TagIds { get; set; } = new List<int>(); // Use Tag IDs in DTO
}
