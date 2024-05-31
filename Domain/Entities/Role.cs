using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Code { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
    }
}
