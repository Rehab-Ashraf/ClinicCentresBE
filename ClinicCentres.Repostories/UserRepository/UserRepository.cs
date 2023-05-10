using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Data.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(ClinicCentresDbContext context, UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            var getrole = await _roleManager.FindByNameAsync("User");
            if (getrole != null)
            {
                var isAdmin = await _userManager.IsInRoleAsync(user, getrole.Name);

                if (isAdmin == false)
                {
                    await _userManager.AddToRoleAsync(user, getrole.Name);
                }

            }

            return result;
        }

        public async Task<User> GetUserByEmailAsync(string name)
        {
            var user = await _userManager.FindByEmailAsync(name);
            return user;
        }

        public async Task<IList<string>> GetUserRoleAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<bool> LoginAsync(User user, string password)
        {
            bool isRightPassword = await _userManager.CheckPasswordAsync(user, password);
            return isRightPassword;
        }
        public async Task<string> Logout()
        {
            await _signInManager.SignOutAsync();
            return "Loged out";
        }

        public async Task<List<Claim>> GetValidClaims(User user)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName)
            };
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userClaims);
            
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("Role", userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                    claims.Add(new Claim("Granted", role.Name));
                }
            }
            return claims;
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }
    }
}
