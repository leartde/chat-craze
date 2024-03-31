using api.Models;

namespace api.Repositories.Extensions
{
    public static class RepositoryPostExtensions
    {
        public static IQueryable<Post> FilterPosts(this IQueryable<Post> posts, string? category, string? username)
        {
            if (category == null && username == null) return posts;

            return posts.Where(p =>
                (category == null || p.Category.Equals(category)) &&
                (username == null || p.User.UserName.Equals(username)));
        }

        public static IQueryable<Post> Search(this IQueryable<Post> posts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return posts;
            var lowerCaseTerm = searchTerm.ToLower();
            return posts.Where(p => p.Title.ToLower().Contains(lowerCaseTerm));

        }
    }
}
