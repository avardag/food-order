using Asp.Versioning;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public FoodController(ILogger<FoodController> logger, ApplicationDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<FoodDto>>CreateFood(NewFoodDto foodDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var food = _mapper.Map<Food>(foodDto); // Using mapper for base food properties

        // Set Category
        var category = await _dbContext.Categories.FindAsync(foodDto.CategoryId);
        if (category == null)
        {
            return BadRequest("Invalid Category Id");
        }
        food.Category = category;

        // Handle Tags
        food.Tags = await _dbContext.Tags.Where(t => foodDto.TagIds.Contains(t.Id)).ToListAsync();

        _dbContext.Foods.Add(food);
        await _dbContext.SaveChangesAsync();

        var foodDtoToReturn = _mapper.Map<FoodDto>(food);

        return CreatedAtAction(nameof(GetFood), new { id = food.Id }, foodDtoToReturn);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FoodDto>> GetFood(int id)
    {
        var food = await _dbContext.Foods
            .Include(f => f.Category) // Eagerly load Category
            .Include(f => f.Tags) // Eagerly load Tags
            .FirstOrDefaultAsync(f => f.Id == id);

        if (food is null)
        {
            return NotFound();
        }

        var foodDto = _mapper.Map<FoodDto>(food);
        return Ok(foodDto);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
    {
        var foods = await _dbContext.Foods
            .Include(f => f.Category) 
            .Include(f=>f.Tags)
            .ToListAsync();
    
        var foodDtos = _mapper.Map<List<FoodDto>>(foods); 
    
        return Ok(foodDtos);
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<List<FoodDto>>> GetFoodByName(string searchTerm)
    {
        var foods = await _dbContext.Foods
            .Include(f => f.Category) // Optional: Include Category
            .Include(f => f.Tags) // Optional: Include Tags
            .Where(f => f.Name.ToLower().Contains(searchTerm)) // Case-insensitive search
            .ToListAsync();
        
        var foodDtos = _mapper.Map<List<FoodDto>>(foods);

        return Ok(foodDtos);
    }

    //route: api/food/tag/<tagname>
    [HttpGet("tag/{tag}")]
    public async Task<ActionResult<List<FoodDto>>> GetFoodByTag(string tag)
    {
        var foodsWithTag = await _dbContext.Foods
            .Include(f => f.Category) // Eagerly load Category (optional)
            .Include(f => f.Tags) // Eagerly load Tags
            .Where(f => f.Tags.Any(t => t.Name == tag))
            .ToListAsync();

        // Map to list of FoodDto and return
        var foodDtos = _mapper.Map<List<FoodDto>>(foodsWithTag);

        return Ok(foodDtos);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id:int}")]
    public async Task<ActionResult<FoodDto>> UpdateFood(int id, NewFoodDto foodDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingFood = await _dbContext.Foods
            .Include(f => f.Tags)
            .Include(f=>f.Category)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (existingFood == null)
        {
            return NotFound();
        }

        // Update basic properties using AutoMapper(no category and tags)
        _mapper.Map(foodDto, existingFood);

        //Update Category
        var category = await _dbContext.Categories.FindAsync(foodDto.CategoryId);
        if (category == null)
        {
            return BadRequest("Invalid Category Id");
        }
        existingFood.Category = category;

        // Update Tags (more efficient approach)
        var existingTagIds = existingFood.Tags.Select(t => t.Id).ToList();
        var newTags = await _dbContext.Tags.Where(t => foodDto.TagIds.Contains(t.Id)).ToListAsync();

        // Remove tags that are no longer associated
        existingFood.Tags.RemoveAll(t => !foodDto.TagIds.Contains(t.Id));

        // Add new tags
        foreach (var newTag in newTags.Where(nt => !existingTagIds.Contains(nt.Id)))
        {
            existingFood.Tags.Add(newTag);
        }

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_dbContext.Foods.Any(f => f.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        var foodDtoToReturn = _mapper.Map<FoodDto>(existingFood);
        return Ok(foodDtoToReturn); // 200 with updated DTO
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFood(int id)
    {
        var foodToDelete = await _dbContext.Foods.FirstOrDefaultAsync(f => f.Id == id);
        if (foodToDelete == null)
            return NotFound();

        // Remove food from the database
        _dbContext.Foods.Remove(foodToDelete);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

}

