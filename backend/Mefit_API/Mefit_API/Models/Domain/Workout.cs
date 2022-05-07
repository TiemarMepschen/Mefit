using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mefit_API.Models.Domain
{
    public class Workout
    {
        // PK
        public int Id { get; set; }

        // Properties
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public bool Completed { get; set; }

        // Relationship
        public int SetId { get; set; }
        public Set Set { get; set; }

        public ICollection<Programme> Programmes { get; set; }

        public ICollection<Goal> Goals { get; set; }
    }
}
