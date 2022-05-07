using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mefit_API.DTOs.Profile
{
    public class ProfileCreateDTO
    {
        // Properties
        public int? CurrentGoalId { get; set; }

        // Relationships
        public int? GoalId { get; set; }
    }
}
