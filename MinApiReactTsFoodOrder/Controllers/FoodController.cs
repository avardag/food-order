using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Data;
using MinApiReactTsFoodOrder.DTOs;
using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.Controllers;

[ApiVersion(1.0)]
[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public FoodController(ILogger<FoodController> logger, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("new")]
    public async Task<ActionResult<Food>> CreateFood(NewFoodDto newFoodDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var food = new Food
        {
            Name = newFoodDto.Name,
            Price = newFoodDto.Price,
            ImageUrl = newFoodDto.ImageUrl,
            Tags = new List<Tag>(),
            Origins = newFoodDto.Origins,
            Stars = newFoodDto.Stars,
            CookTime = newFoodDto.CookTime
        };

        foreach (var tag in newFoodDto.Tags)
        {
            var newTag = new Tag
            {
                Name = tag.Name,
                Id = tag.Id
            };
            food.Tags.Add(newTag);
        }

        _dbContext.Foods.Add(food);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFood), new { id = food.Id }, food);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Food>> GetFood(int id)
    {
        var food = await _dbContext.Foods.FindAsync(id);

        if (food is null)
        {
            return NotFound();
        }

        return Ok(food);
    }
    
    [HttpGet("search/{searchTerm}")]
    public IActionResult GetFoodByName(string searchTerm)
    {
        var food = _dbContext.Foods.FirstOrDefault(f => f.Name.ToLower() == searchTerm.ToLower());
        if (food == null)
            return NotFound($"Food with name '{searchTerm}' not found.");

        return Ok(food);
    }
    
    [HttpGet("tag/{tag}")]
    public IActionResult GetFoodByTag(string tag)
    {
        var foodsWithTag = _dbContext.Foods
            .Where(f => f.Tags.Any(t => t.Name == tag))
            .ToList();
//TODO:
        // if (foodsWithTag.Count == 0)
        //     return NotFound($"No food items found with tag '{tag}'.");

        return Ok(foodsWithTag);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFood(int id, Food updatedFood)
    {
        var existingFood = _dbContext.Foods.FirstOrDefault(f => f.Id == id);
        if (existingFood == null)
            return NotFound();

        // Update properties of existingFood with values from updatedFood
        // Save changes to the database
        _dbContext.SaveChanges();
        return Ok(existingFood);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteFood(int id)
    {
        var foodToDelete = _dbContext.Foods.FirstOrDefault(f => f.Id == id);
        if (foodToDelete == null)
            return NotFound();

        // Remove food from the database
        _dbContext.Foods.Remove(foodToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Food>>> ListFoods()
    {
        var foodsFromDb = await _dbContext.Foods.ToListAsync();

        return Ok(foodsFromDb);
    }
}

