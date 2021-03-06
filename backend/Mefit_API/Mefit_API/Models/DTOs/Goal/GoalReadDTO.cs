using System;
using System.Collections.Generic;

namespace Mefit_API.Models.DTOs.Goal
{
    public class GoalReadDTO
    {
        // PK
        public int Id { get; set; }

        // Properties
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }

        // Relationships
        public int? ProgrammeId { get; set; }
        public List<int> CompletedWorkouts { get; set; }
    }
}
