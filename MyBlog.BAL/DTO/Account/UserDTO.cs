using System.ComponentModel.DataAnnotations;

namespace MyBlog.BLL.DTO.Account
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int? RoleDTOId { get; set; }
        public RoleDTO RoleDTO { get; set; }
    }
}
