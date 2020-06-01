using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.ViewModel;

namespace MyBlog.Web.Components
{
    public class BlogsPage : ViewComponent
    {
        public IViewComponentResult Invoke(PageCounter pageCounter)
        {
            return View(pageCounter);
        }
    }
}
