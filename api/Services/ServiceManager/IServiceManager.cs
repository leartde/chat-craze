using api.Services.PostService;

namespace api.Services.ServiceManager
{
    public interface IServiceManager
    {
        IPostService PostService { get; }
    }
}
