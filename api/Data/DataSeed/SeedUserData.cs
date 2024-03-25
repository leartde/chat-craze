using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.DataSeed
{
    public class SeedUserData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    Username = "Leart"
                },
                new AppUser
                {
                    Id = 2,
                    Username = "Johny"
                }
                );
        }
    }
}
