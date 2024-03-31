using api.Services.PostServices;
using api.Services.UserServices;

namespace api.Services.ServicesManager
{
    public interface IServiceManager
    {
        IPostService PostService { get; }
        IUserService UserService { get; }
    }
}
