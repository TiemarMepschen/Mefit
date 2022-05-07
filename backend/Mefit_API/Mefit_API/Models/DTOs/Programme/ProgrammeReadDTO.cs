using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mefit_API.Models.DTOs.Programme
{
    public class ProgrammeReadDTO
    {
        // PK
        public int Id { get; set; }

        // Properties
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Relationships
        public List<int> Workouts { get; set; }
    }
}
