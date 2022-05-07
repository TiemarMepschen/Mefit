using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mefit_API.Models.DTOs.Workout
{
    public class WorkoutReadDTO
    {
        // PK
        public int Id { get; set; }

        // Properties
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public bool Completed { get; set; }

        // Relationships
        public int SetId { get; set; }

        public List<int> Programmes { get; set; }
        public List<int> CompletedInGoal { get; set; }
    }
}
