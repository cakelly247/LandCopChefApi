using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LccApi.Models.Reply;
using LccApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LccApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReplyController : ControllerBase
{
    private readonly IReplyService _replyService;

    public ReplyController(IReplyService replyService)
    {
        _replyService = replyService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateReply([FromBody] CreateReplyModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var reply = await _replyService.CreateReplyAsync(model);
        if (reply is not null)
        {
            return Ok(reply);
        }

        return BadRequest(reply);
    }

    [HttpGet("GetForComment/{commentId}")]
    public async Task<IActionResult> GetRepliesByCommentId(int commentId)
    {
        if (commentId < 1)
        {
            return BadRequest();
        }

        var replies = await _replyService.GetRepliesByCommentIdAsync(commentId);
        return Ok(replies);
    }
}
