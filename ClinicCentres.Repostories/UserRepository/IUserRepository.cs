using ClinicCentres.Core.DomainEntities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.UserRepository
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task<bool> LoginAsync(User user, string password);
        Task<User> GetUserByEmailAsync(string name);
        Task<IList<string>> GetUserRoleAsync(User userId);
        public Task<List<Claim>> GetValidClaims(User user);
        Task<string> Logout();
        Task<User> GetUserById(string id);
    }
}
