using api.DataTransferObjects.UserDtos;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace api.DataTransferObjects.ValueResolvers;

public class RolesResolver : IValueResolver<AppUser, UserDto, string?>
{
    private readonly UserManager<AppUser> _userManager;

    public RolesResolver(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public string? Resolve(AppUser source, UserDto destination, string? destMember, ResolutionContext context)
    {
        var roles = _userManager.GetRolesAsync(source).Result;
        return roles.FirstOrDefault();
    }
}
