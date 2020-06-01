using MyBlog.BLL.DTO;
using System.Collections.Generic;

namespace MyBlog.Web.ViewModel
{
    public class BlogsViewModel
    {
        public PageCounter pageCounter;
        public List<BlogDTO> blogs;
    }
}
