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
        var comment = await FetchCommentAsync(postId, commentId);
        var replies = await _repository.Reply.GetRepliesForCommentAsync(comment.Id);
        return _mapper.Map<IEnumerable<ReplyDto>>(replies);
    }

    public async Task<ReplyDto> GetReplyForCommentAsync(int id, int commentId, int postId)
    {
        var comment = await FetchCommentAsync(postId, commentId);
        var reply = await _repository.Reply.GetReplyForCommentAsync(comment!.Id, id);
        if (reply is null) throw new NotFoundException("Reply not found");
        return _mapper.Map<ReplyDto>(reply);
    }

    public async Task CreateReplyForCommentAsync(int commentId, int postId, AddReplyDto addReplyDto)
    {
        var comment = await FetchCommentAsync(postId, commentId);
        var reply = _mapper.Map<Reply>(addReplyDto);
         reply.CommentId = comment.Id;
        _repository.Reply.CreateReply(reply);
        await _repository.SaveAsync();
    }

    public async Task UpdateReplyForCommentAsync(string userId, int commentId, int postId)
    {
        await FetchCommentAsync(postId, commentId);
        //TODO - IMPLEMENT
    }

    public async Task DeleteReplyForCommentAsync(string userId, int commentId, int postId)
    {
        await FetchCommentAsync(postId, commentId);
        //TODO - IMPLEMENT
    }

    private async Task<Comment> FetchCommentAsync(int postId, int id)
    {
        var post = await _repository.Post.GetPostAsync(postId);
        if (post is null) throw new NotFoundException($"Post with id {postId} not found ");
        var comment = await _repository.Comment.GetCommentForPostAsync(id, postId);
        if (comment is null)
            throw new NotFoundException($"Post with id {postId} doesn't have a comment with id {id}");
        return comment;
    }
}