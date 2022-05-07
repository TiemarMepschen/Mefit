using System.ComponentModel.DataAnnotations;

namespace Mefit_API.Models.Domain
{
    public class Exercise
    {
        // PK
        public int Id { get; set; }

        // Properties
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
