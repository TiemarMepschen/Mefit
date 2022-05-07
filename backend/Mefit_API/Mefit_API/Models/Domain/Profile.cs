using Mefit_API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mefit_API.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int? CurrentGoalId { get; set; }
        public Goal Goal { get; set; }
        public int? GoalId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
