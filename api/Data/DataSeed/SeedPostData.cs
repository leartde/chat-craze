using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.DataSeed
{
    public class SeedPostData : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post
                {
                    Id = 1,
                    UserId = 1,
                    Title = "Welcome to my blog",
                    Content = "Welcome to my blog Welcome to my blog Welcome to my blog",
                    Category = "Technology",
                    CreatedAt = DateTime.Now,
                    ImageUrl = ""
                },
                new Post
                {
                    Id = 2,
                    UserId = 2,
                    Title = "Welcome to my other blog",
                    Content = "Welcome to my gaming blog Welcome to my gaming blog Welcome to my blog",
                    Category = "Gaming",
                    CreatedAt = DateTime.Now,
                    ImageUrl = ""
                }
                );
        }
    }
}
