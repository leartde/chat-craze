using api.Data;
using api.Models;
using AutoMapper;
using api.DataTransferObjects.PostDtos.api.DataTransferObjects.PostDtos;
using api.Exceptions;

namespace api.DataTransferObjects.ValueResolvers
{
    public class LikesResolver : IValueResolver<Post, PostDto, int>
    {
        private readonly ApplicationDbContext _context;

        public LikesResolver(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Resolve(Post source, PostDto destination, int destMember, ResolutionContext context)
        {
            if (_context.Likes is null) throw new BadRequestException("Error mapping dtos");
            var postLikes = _context.Likes.Count(l => l.PostId == source.Id);
            return postLikes;
        }

        
    }
}

