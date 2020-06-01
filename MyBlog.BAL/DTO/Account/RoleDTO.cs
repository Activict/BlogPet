using System.ComponentModel.DataAnnotations;

namespace MyBlog.BLL.DTO.Account
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
