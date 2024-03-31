using api.ActionFilters;
using api.RequestFeatures;
using api.Services.ServicesManager;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            if (post == null) return NotFound($"Post with id {id} does not exist");
            return Ok(post);
        }
        //[HttpGet("category/{category}")]
        //public async Task<IActionResult> GetPostsByCategory(string category)
        //{
        //    var posts = await _service.PostService.GetPostsByCategoryAsync(category);
        //    if (posts == null) return NotFound($"No posts found with {category} category");    
        //    return Ok(posts);
        //}

    }
}
