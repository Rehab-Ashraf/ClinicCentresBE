using Microsoft.AspNetCore.Identity;
using System;

namespace ClinicCentres.Core.DomainEntities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
