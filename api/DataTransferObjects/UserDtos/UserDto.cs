﻿
namespace api.DataTransferObjects.UserDtos
{
    public class UserDto 
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set;} = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string? Role { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
