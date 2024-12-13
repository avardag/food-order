using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Data;
using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.Controllers;

[ApiVersion(1.0)]
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ILogger<FoodController> logger, ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    // GET: api/category
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categories = await _context.Categories
            .ToListAsync();
        return Ok(categories);
    }
}