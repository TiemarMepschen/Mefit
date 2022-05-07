using System;

namespace Mefit_API.Models.DTOs.Goal
{
    public class GoalCreateDTO
    {
        // Properties
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }

        // Relationships
        public int? ProgrammeId { get; set; }
    }
}
