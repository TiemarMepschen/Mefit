using System;
using System.Collections.Generic;

namespace Mefit_API.Models.Domain
{
    public class Goal
    {
        // PK
        public int Id { get; set; }

        // Properties
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }

        // Relationships
        public int? ProgrammeId { get; set; }
        public Programme Programme { get; set; }

        public ICollection<Workout> Workouts { get; set; }

    }
}
