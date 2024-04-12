using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.DataSeed
{
    public class SeedUserData : IEntityTypeConfiguration<AppUser>
    {
        public  void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var user1 = new AppUser
            {
                Id = "f0f3cf67-9f60-4ee5-9297-e3d93a4878d8",
                Email = "user1@example.com",
                NormalizedEmail = "USER1@EXAMPLE.COM",
                UserName = "User1",
                NormalizedUserName = "USER1",
                CreatedAt = DateTime.Now,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            user1.PasswordHash = passwordHasher.HashPassword(user1, "secret1234.");

            var user2 = new AppUser
            {
                Id = "f01dd69f-1133-4142-aebe-c5664da67cbd",
                Email = "user2@example.com",
                NormalizedEmail = "USER2@EXAMPLE.COM",
                UserName = "user2",
                NormalizedUserName = "USER2",
                CreatedAt = DateTime.Now,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            user2.PasswordHash = passwordHasher.HashPassword(user2, "User2password");
            var user3 = new AppUser
            {
                Id = "4deff5ee-fc72-4dca-a13d-3ffeb86b7d5a",
                Email = "leartde@gmail.com",
                NormalizedEmail = "LEARTDE@GMAIL.COM",
                UserName = "leartde",
                NormalizedUserName = "LEARTDE",
                CreatedAt = DateTime.Now,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            user3.PasswordHash = passwordHasher.HashPassword(user3, "randompass123");
            builder.HasData(
                user1,
                user2,
                user3
                );
        }
    }


}
