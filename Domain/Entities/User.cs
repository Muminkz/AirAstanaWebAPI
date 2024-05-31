using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
