using AutoMapper;
using MyBlog.BLL.DTO;
using MyBlog.BLL.DTO.Account;
using MyBlog.BLL.Interfaces;
using MyBlog.DAL.Entities;
using MyBlog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.BLL.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork uof;
        private readonly IMapper mapper;

        public BlogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uof = unitOfWork;
            this.mapper = mapper;
        }
        
        public void Create(BlogDTO blogDTO)
        {
            Blog blog = mapper.Map<Blog>(blogDTO);
            uof.Blogs.Create(blog);
            uof.Save();
        }

        public void Delete(int id)
        {
            uof.Blogs.Delete(id);
            uof.Save();
        }

        public void Edit(BlogDTO blogDTO)
        {
            Blog blog = uof.Blogs.Get(blogDTO.Id);
            if (blog == null) return;

            blog.Title = blogDTO.Title;
            blog.DateLastChange = blogDTO.DateLastChange;
            blog.Body = blogDTO.Body;
            
            uof.Blogs.Update(blog);
            uof.Save();
        }

        public BlogDTO Get(int id)
        {
            Blog blog = uof.Blogs.Get(id);
            if (blog == null) return null;
            
            var blogDTO = mapper.Map<BlogDTO>(blog);
            return blogDTO;
        }

        public List<BlogDTO> GetAll()
        {
            var blogsDTO = new List<BlogDTO>();
            var blogs = uof.Blogs.GetAll();

            blogs.ToList().ForEach(blog => blogsDTO.Add(mapper.Map<BlogDTO>(blog))); 

            return blogsDTO;
        }

        public async Task<BlogDTO> GetAsync(int id)
        {
            Blog blog = await uof.Blogs.GetAsync(id);
            if (blog == null) return null;

            var blogDTO = mapper.Map<BlogDTO>(blog);
            return blogDTO;
        }

        public async Task<List<BlogDTO>> GetAllAsync()
        {
            var blogsDTO = new List<BlogDTO>();
            var blogs = await uof.Blogs.GetAllAsync();

            blogs.ToList().ForEach(blog => blogsDTO.Add(mapper.Map<BlogDTO>(blog)));

            return blogsDTO;
        }

        public async Task<List<BlogDTO>> GetForPage(int skip, int take)
        {
            List<BlogDTO> blogs = GetAll()
                .OrderByDescending(b => b.DateCreated)
                .Skip(skip)
                .Take(take)
                .ToList();
            return blogs;
        }

        public void Dispose()
        {
            uof.Dispose();
        }
    }
}
