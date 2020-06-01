using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.DAL.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastChange { get; set; }
        [Required]
        public string Body { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
