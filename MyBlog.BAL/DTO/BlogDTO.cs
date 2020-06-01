using MyBlog.BLL.DTO.Account;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.BLL.DTO
{
    public class BlogDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(70, ErrorMessage ="Максимальная длина не должна превышать 70 символов")]
        public string Title { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastChange { get; set; }
        [Required(ErrorMessage ="Не должно быть пустым")]
        public string Body { get; set; }

        public int UserDTOId { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
