using api.Contracts;
using api.DataTransferObjects.ReplyDtos;
using api.Exceptions;
using api.Models;
using AutoMapper;

namespace api.Services.ReplyServices;

public class ReplyService : IReplyService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public ReplyService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ReplyDto>> GetRepliesForCommentAsync(int commentId, int postId)
    {
        await EnsurePostAndCommentExistAsync(postId, commentId);
        var comment = await _repository.Comment.GetCommentForPostAsync(commentId, postId);
        var replies = await _repository.Reply.GetRepliesForCommentAsync(comment!.Id);
        return _mapper.Map<IEnumerable<ReplyDto>>(replies);
    }

    public async Task<ReplyDto> GetReplyForCommentAsync(int id, int commentId, int postId)
    {
        await EnsurePostAndCommentExistAsync(postId, commentId);
        var comment = await _repository.Comment.GetCommentForPostAsync(commentId, postId);
        var reply = await _repository.Reply.GetReplyForCommentAsync(comment!.Id, id);
        if (reply is null) throw new NotFoundException("Reply not found");
        return _mapper.Map<ReplyDto>(reply);
    }

    public async Task CreateReplyForCommentAsync(int commentId, int postId, AddReplyDto addReplyDto)
    {
        await EnsurePostAndCommentExistAsync(postId, commentId);
        var comment = await _repository.Comment.GetCommentForPostAsync(commentId, postId);
        var reply = _mapper.Map<Reply>(addReplyDto);
        reply.CommentId = comment!.Id;
        _repository.Reply.CreateReply(reply);
        await _repository.SaveAsync();
    }

    public async Task UpdateReplyForCommentAsync(string userId, int commentId, int postId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteReplyForCommentAsync(string userId, int commentId, int postId)
    {
        throw new NotImplementedException();
    }

    private async Task CheckIfCommentExists(int commentId, int postId)
    {
        var comment = await _repository.Comment.GetCommentForPostAsync(commentId, postId);
        if (comment is null) throw new NotFoundException("Comment not found.");
    }
    private async Task CheckIfPostExists(int postId)
    {
        var post = await _repository.Post.GetPostAsync(postId);
        if (post is null) throw new NotFoundException("Post not found.");
    }
    
    private async Task EnsurePostAndCommentExistAsync(int postId, int commentId)
    {
        await CheckIfPostExists(postId);
        await CheckIfCommentExists(commentId, postId);
    }
}