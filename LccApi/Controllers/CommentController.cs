using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LccApi.Data;
using LccApi.Models;

namespace LccApi.Controllers;


[Route("Comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly LccDbContext _context;

    public CommentController(LccDbContext context)
    {
        _context = context;
    }
[HttpPost]
public async Task<IActionResult> CreateComment(CommentModel comment)
{
    _context.Comments.Add(comment);
    await _context.SaveChangesAsync();
    return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
}

[HttpGet("byauthor/{authorId}")]
public async Task<IActionResult> GetCommentsByAuthorId(int authorId)
{
    var comments = await _context.Comments
        .Where(c => c.AuthorId == authorId)
        .ToListAsync();
    return Ok(comments);
}

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComment(int id, CommentModel comment)
    {
        if (id != comment.Id)
        {
            return BadRequest();
        }

        _context.Entry(comment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommentExists(id))
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

   [HttpDelete("{id}")]
public async Task<IActionResult> DeleteComment(int id)
{
    var comment = await _context.Comments.FindAsync(id);
    if (comment == null)
    {
        return NotFound();
    }

    _context.Comments.Remove(comment);
    await _context.SaveChangesAsync();

    return NoContent();
}

    private bool CommentExists(int id)
    {
        return _context.Comments.Any(c => c.Id == id);
    }
}