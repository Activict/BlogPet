using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.DTO;
using MyBlog.BLL.Interfaces;
using MyBlog.Web.ViewModel;

namespace MyBlog.Web.Controllers
{
    [Authorize(Roles ="admin, user")]
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private PageCounter pageCounter;
        private readonly IUserService userService;

        public BlogController(IBlogService blogService, PageCounter pageCounter, IUserService userService)
        {
            this.blogService = blogService;
            this.pageCounter = pageCounter;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            pageCounter.UpdatePage(page);

            var blogsViewModel = new BlogsViewModel();
            blogsViewModel.pageCounter = pageCounter;
            blogsViewModel.blogs = await blogService.GetForPage(pageCounter.Skip, pageCounter.BlogsOnPage);
            return View(blogsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var blog = await blogService.GetAsync(id);
            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var blog = await blogService.GetAsync(id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Update(BlogDTO blogDTO)
        {
            blogDTO.DateLastChange = DateTime.Now;
            blogService.Edit(blogDTO);
            return RedirectToRoute("default", new { controller = "Blog", action = "Details", id = blogDTO.Id.ToString() });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogDTO blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            blog.DateCreated = DateTime.Now;
            blog.UserDTOId = userService
                .GetAll()
                .FirstOrDefault(u => u.Login == HttpContext.User.Identity.Name).Id;
            blogService.Create(blog);

            int? blogId = blogService
                .GetAll()
                .FirstOrDefault(b => b.DateCreated == blog.DateCreated && b.UserDTOId == blog.UserDTOId)?.Id;

            pageCounter.UpdatePagesCount(blogService);

            return RedirectToRoute("default", new { controller = "Blog", action = "Details", id = blogId.ToString() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await blogService.GetAsync(id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Delete(BlogDTO blog)
        {
            blogService.Delete(blog.Id);
            pageCounter.UpdatePagesCount(blogService);
            return RedirectToAction("Index");
        }
    }
}