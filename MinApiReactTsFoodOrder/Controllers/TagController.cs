using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinApiReactTsFoodOrder.Data;
using MinApiReactTsFoodOrder.DTOs;
using MinApiReactTsFoodOrder.Entities;

namespace MinApiReactTsFoodOrder.Controllers;

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

            return tag;
        }

        // POST: api/tags
        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag(NewTagDto newTagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTag = new Tag
            {
                Name = newTagDto.Name
            };
            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTag), new { id = newTag.Id }, newTag);
        }

        // PUT: api/tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, TagDto tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }
            //find tag in db
            var existingTag = await _context.Tags.FindAsync(id);
            if (existingTag == null)
            {
                return NotFound();
            }
            //update existing tag
            existingTag.Name = tag.Name;

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

            return NoContent();
        }

        // DELETE: api/tags/5
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