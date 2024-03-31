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
                    UserId = "f0f3cf67-9f60-4ee5-9297-e3d93a4878d8",
                    Title = "Welcome to my blog",
                    Content = "Welcome to my blog Welcome to my blog Welcome to my blog",
                    Category = "Technology",
                    CreatedAt = DateTime.Now,
                    ImageUrl = ""
                },
                new Post
                {
                    Id = 2,
                    UserId = "f01dd69f-1133-4142-aebe-c5664da67cbd",
                    Title = "THREAD ABOUT GAMING",
                    Content = "Welcome to my gaming blog Welcome to my gaming blog Welcome to my blog",
                    Category = "Gaming",
                    CreatedAt = DateTime.Now,
                    ImageUrl = ""
                },
               new Post
               {
                   Id = 3,
                   UserId = "4deff5ee-fc72-4dca-a13d-3ffeb86b7d5a",
                   Title = "Leart's post",
                   Content = "Hello welcome to my post",
                   Category = "Coding",
                   CreatedAt = DateTime.Now,
                   ImageUrl = ""
               }
                );
        }
    }
}
