using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Interfaces.Account;
using Restaurant.Core.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Core.Application.Enums;
using Restaurant.Infrastructure.Identity.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace Restaurant.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager; // crud de usuario
        private readonly SignInManager<ApplicationUser> _signInManager; //log in / log out
        private readonly JWTSettings _jwtSettings;



        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> jWTSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jWTSettings.Value;


        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                response.HasError = true;
                response.Error = $"Account not registed with UserName {request.UserName}";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Invalid credentials for {request.UserName}";
                return response;
            }

            if (!user.EmailConfirmed)
            {
                response.HasError = true;
                response.Error = $"Account no confirmed {request.UserName}";
                return response;
            }


            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            response.Id = user.Id;
            response.UserName = user.UserName;
            response.Email = user.Email;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshToken = GenerateRefreshToken();
            response.RefreshToken = refreshToken.Token;

            return response;

        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterResponse> RegisterWaiterAsync(RegisterRequest request)
        {
            RegisterResponse response = new();
            response.HasError = false;

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"UserName {request.UserName} is already taken.";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumber = request.Tel
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"An error occured while registering user";
                return response;
            }
            else
            {
                await _userManager.AddToRoleAsync(user, Roles.Waiter.ToString());
            }

            return response;
        }



        public async Task<RegisterResponse> RegisterAdminAsync(RegisterRequest request)
        {
            RegisterResponse response = new();
            response.HasError = false;

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"UserName {request.UserName} is already taken.";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumber = request.Tel
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"An error occured while registering user";
                return response;
            }
            else
            {
                await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                await _userManager.AddToRoleAsync(user, Roles.Waiter.ToString());
            }

            return response;
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmectricSecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredetials = new SigningCredentials(symmectricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredetials);

            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var ramdomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(ramdomBytes);

            return BitConverter.ToString(ramdomBytes).Replace("-", "");
        }





    }
}
