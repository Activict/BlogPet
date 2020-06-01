using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.DTO;
using MyBlog.BLL.Interfaces;
using MyBlog.DAL.Entities;
using System.IO;
using System.Text;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService blogService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string path = "/files/listtodo.html";

        public HomeController(IBlogService blogService, IWebHostEnvironment webHostEnvironment)
        {
            this.blogService = blogService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string html = default;
            var filepath = webHostEnvironment.WebRootPath + path;
            if (System.IO.File.Exists(filepath))
            {
                using (var sr = new StreamReader(filepath))
                {
                    html = sr.ReadToEnd();
                }
            }
            var model = new BlogDTO { Body = html };
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveHtml(BlogDTO model)
        {
            var filepath = webHostEnvironment.WebRootPath + path;
            using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.Default))
            {
                sw.Write(model.Body);
            }
            return View("Index");
        }
    }
}