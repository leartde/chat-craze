using api.DataTransferObjects.CommentDtos;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/posts/{postId}/comments")]
    public class CommentController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CommentController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsForPost(int postId)
        {
            var comments = await _service.CommentService.GetCommentsForPostAsync(postId);
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentForPost(int id, int postId)
        {
            var comment = await _service.CommentService.GetCommentForPostAsync(id, postId);
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(int postId, AddCommentDto addCommentDto)
        {
            await _service.CommentService.CreateCommentAsync(postId, addCommentDto);
            return Ok("Comment created successfully");
        }

        [HttpGet("/api/users/{userId}/comments")]
        public async Task<IActionResult> GetCommentsForUser(string userId)
        {
            var comments = await _service.CommentService.GetCommentsForUserAsync(userId);
            return Ok(comments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentForPosst(int id, int postId, UpdateCommentDto updateCommentDto)
        {
            await _service.CommentService.UpdateCommentAsync(id, postId, updateCommentDto);
            return Ok("Comment successfully updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentForPost(int id, int postId)
        {
            await _service.CommentService.DeleteCommentAsync(id, postId);
            return Ok("Comment successfully deleted.");
        }
        
    }
}
