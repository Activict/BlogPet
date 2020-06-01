using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.DTO;
using MyBlog.BLL.Interfaces;

namespace MyBlog.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private IBlogService blogService;

        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDTO>>> GetAll()
        {
            return await blogService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDTO>> Get(int id)
        {
            BlogDTO blog = await blogService.GetAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return new ObjectResult(blog);
        }
    }
}