using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LccApi.Data;
using LccApi.Models;

public class PostController : ControllerBase, IPostController
{
    private readonly LccDbContext _context;

    public PostController(LccDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> GetPosts()
    {
        var posts = await _context.Posts.ToListAsync();
        return Ok(posts);
    }

    public async Task<IActionResult> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    public async Task<IActionResult> CreatePost(PostModel post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPost", new { id = post.Id }, post);
    }

    public async Task<IActionResult> UpdatePost(int id, PostModel post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }

        _context.Entry(post).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PostExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PostExists(int id)
    {
        return _context.Posts.Any(e => e.Id == id);
    }
}
