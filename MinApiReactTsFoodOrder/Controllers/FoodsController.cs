using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Data;
using MinApiReactTsFoodOrder.DTOs;
using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.Controllers;

[ApiVersion( 1.0 )]
[ApiController]
[Route("api/[controller]" )]
public class FoodsController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public FoodsController(ILogger<FoodsController> logger, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [Authorize (Roles = "Admin")]
    [HttpPost("new")]
    public async Task<ActionResult<Food>> CreateFood(FoodDto foodDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var food = new Food
        {
            Name = foodDto.Name,
            Price = foodDto.Price,
            ImageUrl = foodDto.ImageUrl,
        };
        
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
        
        return food;
    }
    
    
    [HttpGet]
    public async Task<List<Food>> ListFoods()
    {
        var foodsFromDb = await _dbContext.Foods.ToListAsync();
     
        
        return foodsFromDb;
    }
}