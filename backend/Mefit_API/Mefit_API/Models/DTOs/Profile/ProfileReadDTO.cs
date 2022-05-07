using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mefit_API.DTOs.Profile
{
    public class ProfileReadDTO
    {
        // PK
        public int Id { get; set; }

        // Properties
        public int? CurrentGoalId { get; set; }

        // Relationships
        public int? GoalId { get; set; }
        public int UserId { get; set; }
    }
}
