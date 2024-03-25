using api.Data.DataSeed;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeedPostData());
            modelBuilder.ApplyConfiguration(new SeedUserData());

        }


        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Friendship> Friendships { get; set; }  
        public DbSet<Reply> Replies { get; set; }
        public DbSet<UsersInterests> UsersInterests { get; set; }
    }
}
