using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
