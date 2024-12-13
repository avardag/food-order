using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Data;
using MinApiReactTsFoodOrder.DTOs;
using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.Controllers;

[ApiVersion(1.0)]
[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TagController(ILogger<FoodController> logger, ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    // GET: api/tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDto>>> GetTags()
        {
            var tags = await _context.Tags
                .Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
            return Ok(tags);
        }

        // GET: api/tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
            {
                return BadRequest("Tag name cannot be empty or whitespace.");
            }

            // Check if tag already exists (case-insensitive)
            var existingTag = await _context.Tags.FirstOrDefaultAsync(t => t.Name.ToLower() == tagName.ToLower());
            if (existingTag != null)
            {
                return Conflict("A tag with this name already exists.");
            }

            var newTag = new Tag { Name = tagName };

            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTag), new { id = newTag.Id }, newTag);
        }

        // PUT: api/tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, string newTagName)
        {
            if (string.IsNullOrWhiteSpace(newTagName))
            {
                return BadRequest("Tag name cannot be empty or whitespace.");
            }

            var tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }
            var existingTag = await _context.Tags.FirstOrDefaultAsync(t => t.Name.ToLower() == newTagName.ToLower() && t.Id != id);
            if (existingTag != null)
            {
                return Conflict("A tag with this name already exists.");
            }

            tag.Name = newTagName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // 204 No Content for successful update
        }

        // DELETE: api/tags/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagExists(int id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
}