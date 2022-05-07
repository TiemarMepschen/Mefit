using System.ComponentModel.DataAnnotations;

namespace Mefit_API.Models.DTOs.Set
{
    public class SetReadDTO
    {
        // PK
        public int Id { get; set; }

        // Properties 
        [Required]
        public int ExerciseRepetition { get; set; }

        // Relationships
        public int ExerciseId { get; set; }
    }
}
