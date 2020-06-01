using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Interfaces;
using System.Threading.Tasks;

namespace MyBlog.Web.Components
{
    public class LeftPanel : ViewComponent
    {
        private readonly IBlogService blogService;

        public LeftPanel(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await blogService.GetAllAsync();

            return View(blogs);
        }
    }
}
