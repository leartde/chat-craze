using api.Models;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace api.Repositories.Extensions
{
    public static class RepositoryPostExtensions
    {
        public static IQueryable<Post> Filter(this IQueryable<Post> posts, string? category , string? username, int? minLikes)
        {
            if (string.IsNullOrWhiteSpace(category) && string.IsNullOrWhiteSpace(username) && minLikes == null)
            {
                try
                {
                    return posts;
                }
                catch(SystemException e)
                {
                    Console.WriteLine("Error fetching posts", e.Message);
                }
            }

            return posts.Where(p =>
                (category == null ||  p.Category.Equals(category)) &&
                (username == null || p.User != null && p.User.UserName != null && p.User.UserName.Contains(username))&&
                (minLikes == null ||  p.Likes.Count>= minLikes)
                );
        }


        public static IQueryable<Post> Search(this IQueryable<Post> posts, string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return posts;

            var lowerCaseTerm = searchTerm.ToLower();
            return posts.Where(p => p.Title.Contains(lowerCaseTerm, StringComparison.CurrentCultureIgnoreCase));
        }

        public static IQueryable<Post> Sort(this IQueryable<Post> posts, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return posts.OrderBy(p => p.CreatedAt);

            var orderParams = orderByQueryString.Trim().Split(' ');
            var propertyName = orderParams[0];
            var isDescending = orderByQueryString.EndsWith(" desc", StringComparison.OrdinalIgnoreCase);
            switch(propertyName.ToLower()){
                case "username":
                    return isDescending ?
                    posts.OrderByDescending(p => p.User != null?p.User.UserName:p.CreatedAt.ToString(CultureInfo.InvariantCulture))
                    : posts.OrderBy(p => p.User != null?p.User.UserName:p.CreatedAt.ToString(CultureInfo.InvariantCulture));
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