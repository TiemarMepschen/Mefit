using System.ComponentModel.DataAnnotations;

namespace Mefit_API.Models.Domain
{
    public class Set
    {
        // PK
        public int Id { get; set; }

        // Properties 
        [Required]
        public int ExerciseRepetition { get; set; }

        // Relationships
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
