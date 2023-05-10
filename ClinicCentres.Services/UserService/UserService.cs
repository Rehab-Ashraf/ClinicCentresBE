using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Repostories.UserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;
        private readonly IConfiguration configuration;
        public UserService(IUserRepository userRepo, IConfiguration configuration)
        {
            this.userRepo = userRepo;
            this.configuration = configuration;
        }

        public async Task<User> GetUserById(string id)
        {
            return await userRepo.GetUserById(id);
        }

        public async Task<string> LoginAsync(string name, string password)
        {
            var user = await userRepo.GetUserByEmailAsync(name);
            //var userRole = await userRepo.GetUserRoleAsync(user);
            if (user == null)
                return null;

            var claims = await userRepo.GetValidClaims(user);
            bool isRightPassword = await userRepo.LoginAsync(user, password);
            if (isRightPassword)
            {
                string bearerToken = GenerateToken(user, claims);
                return bearerToken;
            }

            return null;
        }

        public async Task<string> Logout()
        {
            return await userRepo.Logout();
        }

        public async Task<IdentityResult> RegisterAsync(User model, string password)
        {
            var result = await userRepo.AddUserAsync(model, password);
            return result;
        }

        private string GenerateToken(User user, IList<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                                issuer: configuration["IdentitySettings:Issuer"],
                                audience: configuration["IdentitySettings:Audience"],
                                claims: claims,
                                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["IdentitySettings:TokenExpiryInMinutes"].ToString())),
                                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["IdentitySettings:SecurityKey"])), SecurityAlgorithms.HmacSha256Signature)
                                );

            var tokenHandler = new JwtSecurityTokenHandler();
            var bearerToken = tokenHandler.WriteToken(jwt);

            return bearerToken;
        }
    }
}
