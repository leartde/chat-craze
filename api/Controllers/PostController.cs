using api.ActionFilters;
using api.RequestFeatures;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using api.DataTransferObjects.PostDtos;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IServiceManager _service;
        public PostController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet] 
        public async Task<IActionResult> GetAllPosts([FromQuery]PostParameters postParameters)
        {
            var pagedResult = await _service.PostService.GetAllPostsAsync(postParameters);
            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _service.PostService.GetPostAsync(id);
            return Ok(post);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _service.PostService.DeletePostAsync(id);
            return Ok("Post successfully deleted");
        }
        [HttpPost]
        public async Task<IActionResult> AddPost([FromForm]AddPostDto postDto)
        {
            await _service.PostService.AddPostAsync(postDto);
            return Ok("Post successfully added");
        }


    }
}
