using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mefit_API.DTOs.User
{
    public class UserCreateDTO
    {
        // Properties
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public string KeycloakId { get; set; }
        public int IsAdmin { get; set; }
        public Profile.ProfileCreateDTO Profile { get; set; }
    }
}
