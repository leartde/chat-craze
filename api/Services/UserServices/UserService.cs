﻿using api.ConfigurationModels;
using api.Contracts;
using api.DataTransferObjects.UserDtos;
using api.Exceptions;
using api.Models;
using api.Services.UserServices;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace api.Services.UserServices
{
    internal sealed class UserService : IUserService
    {

        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private AppUser? _user;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper,
            UserManager<AppUser> userManager, IConfiguration configuration,
            IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfiguration = new JwtConfiguration();
            _repository = repository;
            _httpContextAccessor = contextAccessor;
            _configuration.Bind(_jwtConfiguration.Section, _jwtConfiguration);
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signInCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signInCredentials, claims);
            var refreshToken = GenerateRefreshToken();

            if (_user != null)
            {
                _user.RefreshToken = refreshToken;
                if (populateExp) _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                await _userManager.UpdateAsync(_user);

            }
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("accessToken", accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            return new TokenDto(accessToken, refreshToken);
        }

        public bool DestroyTokens()
        {
            var context = _httpContextAccessor.HttpContext;
            var accessToken = context?.Request.Cookies["accessToken"];
            var refreshToken = context?.Request.Cookies["refreshToken"];
            if (accessToken is null || refreshToken is null)
            {
                return false;
            }
            context?.Response.Cookies.Delete("accessToken");
            context?.Response.Cookies.Delete("refreshToken");
            return true;
            
        }

        
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials
         , List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtConfiguration.ValidIssuer,
                audience: _jwtConfiguration.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
                );
            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>();
            if (_user?.UserName == null) return claims;
            claims.Add(
                new Claim("username", _user.UserName)
            );
            if (!string.IsNullOrEmpty(_user.Email) && !string.IsNullOrEmpty(_user.Id))
            {
                claims.Add(new Claim("email", _user.Email));
                claims.Add(new Claim("id", _user.Id));
                claims.Add(new Claim("avatarUrl", !string.IsNullOrEmpty(_user.AvatarUrl) ? _user.AvatarUrl : ""));

            }
            var roles = await _userManager.GetRolesAsync(_user);
            var role = roles.FirstOrDefault();
            claims.Add(new Claim("role", role!));

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<IdentityResult> RegisterUser(AddUserDto addUserDto)
        {

            var user = _mapper.Map<AppUser>(addUserDto);
            
            var result = await _userManager.CreateAsync(user, addUserDto.Password);
            List<string> roles = ["User"];
            if (result.Succeeded)   
            {
                await _userManager.AddToRolesAsync(user, roles);
            }
            return result;
        }

        public async Task<bool> ValidateUser(AuthenticateUserDto authenticateUserDto)
        {
                _user = await _userManager.FindByNameAsync(authenticateUserDto.UserName);
            var result = (_user != null && await _userManager
                .CheckPasswordAsync(_user, authenticateUserDto.Password));
            if (!result)
            {
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed.Wrong username or password");
            }
            return result;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")!)
                ),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg
                    .Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            if (principal.Identity == null) return new ClaimsPrincipal();
            var identity = new ClaimsIdentity(principal.Claims, principal.Identity.AuthenticationType, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var usernameClaim = identity.FindFirst("username");
            if (usernameClaim != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, usernameClaim.Value));
            }
            var newPrincipal = new ClaimsPrincipal(identity);

            return newPrincipal;
        }
        
        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            if (principal.Identity == null) return await CreateToken(populateExp: false);
            if (principal.Identity.Name == null) return await CreateToken(populateExp: false);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user is null || user.RefreshToken != tokenDto.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new BadRequestException("Invalid client request. The tokenDto has some invalid values");
            }
            _user = user;

            return await CreateToken(populateExp: false);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _repository.User.GetAllUsersAsync();
            return  _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null) throw new NotFoundException($"User with id {id} not found.");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByUsernameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user is null) 
                throw new NotFoundException($"User with username {userName} not found.");
            return _mapper.Map<UserDto>(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user is null) throw new NotFoundException($"User with id {id} not found.");
            await _userManager.DeleteAsync(user);
            await _repository.SaveAsync();
        }

        public async Task UpdateUserAsync(string id, UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null) throw new NotFoundException($"User with id {id} not found.");
             ValidateUserEdit(updateUserDto);
            _mapper.Map(updateUserDto,user);
            await _userManager.UpdateAsync(user);
            await _repository.SaveAsync();
            
        }

        private void ValidateUserEdit(UpdateUserDto updateUserDto)
        {
            if (string.IsNullOrWhiteSpace(updateUserDto.Email)) throw new BadRequestException("User email is required");
            if (string.IsNullOrWhiteSpace(updateUserDto.UserName)) throw new BadRequestException("Username is required");
            if(updateUserDto.UserName.Trim().Length < 4 || updateUserDto.UserName.Trim().Length > 20) throw new BadRequestException("Username must be between 6 and 20 characters.");

        }
    }
    
    
}
