using api.Contracts;
using api.Data;
using api.DataTransferObjects.PostDtos;
using api.Models;
using AutoMapper;
using System.Linq;
using api.DataTransferObjects.PostDtos.api.DataTransferObjects.PostDtos;

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
            var postLikes = _context.Likes.Where(l => l.PostId == source.Id).Count();
            return postLikes;
        }

        
    }
}

