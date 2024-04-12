using api.DataTransferObjects.ReplyDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController]
[Route("/api/posts/{postId}/comments/{commentId}/replies")]
public class ReplyController : ControllerBase
{
    private readonly IServiceManager _service;

    public ReplyController(IServiceManager service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetRepliesForComment(int postId, int  commentId)
    {
        var replies = await _service
            .ReplyService.GetRepliesForCommentAsync(postId, commentId);
        return Ok(replies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReplyForComment(int id, int commentId, int postId)
    {
        var reply = await _service.ReplyService.GetReplyForCommentAsync(id, commentId, postId);
        return Ok(reply);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReplyForComment(int commentId, int postId, AddReplyDto addReplyDto)
    {
        await _service.ReplyService.CreateReplyForCommentAsync(commentId, postId, addReplyDto);
        return Ok("Reply successfully added.");
    }
}