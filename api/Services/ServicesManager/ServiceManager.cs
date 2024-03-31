using api.Contracts;
using api.Models;
using api.Services.PostServices;
using api.Services.UserServices;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace api.Services.ServicesManager
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPostService> _postService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,
            IMapper mapper, UserManager<AppUser> userManager,IConfiguration configuration
            )
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper, userManager, configuration));
            _postService = new Lazy<IPostService>(() => new PostService(repositoryManager, mapper));
           
        }

        public IPostService PostService => _postService.Value;

        public IUserService UserService => _userService.Value;

        
    }
}
