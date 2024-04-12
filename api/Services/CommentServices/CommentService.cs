using api.Contracts;
using api.DataTransferObjects.CommentDtos;
using api.Exceptions;
using api.Models;
using AutoMapper;

namespace api.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public CommentService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       public async Task CreateCommentAsync(int postId, AddCommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            comment.PostId = postId;
            _repository.Comment.CreateComment(comment);
            await _repository.SaveAsync();

        }

        public async Task UpdateCommentAsync(int id, int postId, UpdateCommentDto updateCommentDto)
        {
            await CheckIfPostExistsAsync(postId);
            var comment = await _repository.Comment.GetCommentForPostAsync(id, postId);
            if (comment is null) throw new NotFoundException("Comment not found");
            comment.Content = updateCommentDto.Content;
            _repository.Comment.UpdateComment(comment);
            await _repository.SaveAsync();
        }

        public async Task DeleteCommentAsync(int id, int postId)
        {
            await CheckIfPostExistsAsync(postId);
            var comment = await _repository.Comment.GetCommentForPostAsync(id, postId);
            if (comment is null) throw new NotFoundException("Comment doesn't exist");
            _repository.Comment.DeleteComment(comment);
            await _repository.SaveAsync();

        }

        public async Task<IEnumerable<CommentDto>> GetCommentsForPostAsync(int postId)
        {
            var comments = await _repository.Comment.GetCommentsForPostAsync(postId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);

}

        public async Task<CommentDto> GetCommentForPostAsync(int id, int postId)
        {
            await CheckIfPostExistsAsync(postId);
            var comment = await _repository.Comment.GetCommentForPostAsync(id, postId);
            if (comment is null) throw new NotFoundException("Comment doesn't exist");
            return _mapper.Map<CommentDto>(comment);
        }

        public Task<IEnumerable<CommentDto>> GetCommentsForUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        private async Task CheckIfPostExistsAsync(int postId)
        {
            var post = await _repository.Post.GetPostAsync(postId);
            if (post is null) throw new NotFoundException($"Post with id {postId} not found.");
        }

        
    }
}
