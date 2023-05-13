using ClinicCentres.Core.DomainEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Services.UserService
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(User model, string password);
        Task<string> LoginAsync(string email, string password);
        Task<string> Logout();
        Task<User> GetUserById(string id);
    }
}
