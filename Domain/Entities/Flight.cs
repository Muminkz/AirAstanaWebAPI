using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Origin { get; set; }
        [Required]
        [StringLength(256)]
        public string Destination { get; set; }
        [Required]
        public DateTimeOffset Departure { get; set; }
        [Required]
        public DateTimeOffset Arrival { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
