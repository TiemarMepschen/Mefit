using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mefit_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KeycloakId { get; set; }
        public int IsAdmin { get; set; }
        public Profile Profile { get; set; }
    }
}
