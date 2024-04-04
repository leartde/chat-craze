using api.Models;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace api.Repositories.Extensions
{
    public static class RepositoryPostExtensions
    {
        public static IQueryable<Post> Filter(this IQueryable<Post> posts, string? category, string? username)
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
        public static IQueryable<Post> Sort(this IQueryable<Post> posts, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return posts.OrderBy(p => p.CreatedAt);

            var orderParams = orderByQueryString.Trim().Split(' ');
            var propertyName = orderParams[0];
            var isDescending = orderByQueryString.EndsWith(" desc", StringComparison.OrdinalIgnoreCase);

            if (propertyName.ToLower() == "username")
            {
                return isDescending ?
                    posts.OrderByDescending(p => p.User.UserName)
                    : posts.OrderBy(p => p.User.UserName);
            }
            switch(propertyName.ToLower()){
                case "username":
                    return isDescending ?
                    posts.OrderByDescending(p => p.User.UserName)
                    : posts.OrderBy(p => p.User.UserName);
                    break;
                case "likecount":
                        return isDescending ?
                    posts.OrderByDescending(p => p.Likes.Count)
                    : posts.OrderBy(p => p.Likes.Count);
            }

            var propertyInfos = typeof(Post).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                throw new ArgumentException($"Invalid property name '{propertyName}'");

            var parameter = Expression.Parameter(typeof(Post), "x");
            var propertyAccess = Expression.Property(parameter, objectProperty);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            var method = isDescending ? "OrderByDescending" : "OrderBy";
            var orderByCall = Expression.Call(
                typeof(Queryable),
                method,
                new[] { typeof(Post), objectProperty.PropertyType },
                posts.Expression,
                Expression.Quote(orderByExp));

            return posts.Provider.CreateQuery<Post>(orderByCall);
        }




    }
}
