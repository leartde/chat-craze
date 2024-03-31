using api.ConfigurationModels;
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
        public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfiguration = new JwtConfiguration();
            _repository = repository;
            _configuration.Bind(_jwtConfiguration.Section, _jwtConfiguration);
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signInCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signInCredentials, claims);
            var refreshToken = GenerateRefreshToken();

            _user.RefreshToken = refreshToken;
            if (populateExp) _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto(accessToken, refreshToken);


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
            var claims = new List<Claim>
            {
                new Claim("username", _user.UserName),           
              };
            if (!string.IsNullOrEmpty(_user.Email) && !string.IsNullOrEmpty(_user.Id))
            {
                claims.Add(new Claim("email", _user.Email));
                claims.Add(new Claim("id", _user.Id));
                if (!string.IsNullOrEmpty(_user.AvatarUrl)){
                    claims.Add(new Claim("avatarUrl", _user.AvatarUrl));
                }
                else
                {
                    claims.Add(new Claim("avatarUrl", ""));
                }
            }
            var roles = await _userManager.GetRolesAsync(_user);
            var role = roles.FirstOrDefault();
                claims.Add(new Claim("role", role));
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<IdentityResult> RegisterUser(AddUserDto addUserDto)
        {

            var user = _mapper.Map<AppUser>(addUserDto);
            
            var result = await _userManager.CreateAsync(user, addUserDto.Password);
            List<string> roles = [addUserDto.Role];
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
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
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
                    Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))
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
            return principal;
        }

        public async Task<TokenDto> RefreshRoken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AcccesToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user is null || user.RefreshToken != tokenDto.RefreshToken ||
              user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new RefreshTokenBadRequest();
            }
            _user = user;
            return await CreateToken(populateExp: false);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _repository.User.GetAllUsersAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return usersDto;
        }
    }
}
