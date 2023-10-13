using LccApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPostController
{
    Task<IActionResult> GetPosts();
    Task<IActionResult> GetPost(int id);
    Task<IActionResult> CreatePost(PostModel post);
    Task<IActionResult> UpdatePost(int id, PostModel post);
    Task<IActionResult> DeletePost(int id);
}
