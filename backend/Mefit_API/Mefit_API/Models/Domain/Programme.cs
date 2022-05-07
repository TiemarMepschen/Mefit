using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mefit_API.Models.Domain
{
    public class Programme
    {
        // PK
        public int Id { get; set; }

        // Properties
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Relationships
        public ICollection<Workout> Workouts { get; set; }
    }
}
