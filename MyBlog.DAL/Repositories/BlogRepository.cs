using Microsoft.EntityFrameworkCore;
using MyBlog.DAL.Entities;
using MyBlog.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.Repositories
{
    class BlogRepository : IRepository<Blog>
    {
        private readonly DataContext context;
        public BlogRepository(DataContext context)
        {
            this.context = context;
        }
        public void Create(Blog blog)
        {
            context.Add(blog);
        }

        public void Delete(int id)
        {
            Blog blog = context.Blogs.Find(id);
            if (blog != null)
            {
                context.Blogs.Remove(blog);
            }
        }

        public IEnumerable<Blog> Find(Func<Blog, bool> predicate)
        {
            return context.Blogs.Where(predicate).ToList();
        }

        public Blog Get(int id)
        {
            return context.Blogs
                .Include(b => b.User.Role)
                .FirstOrDefault(b => b.Id == id);
        }

        public async Task<Blog> GetAsync(int id)
        {
            return await context.Blogs
                .Include(b => b.User.Role)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public IEnumerable<Blog> GetAll()
        {
            var blogs = context.Blogs.Include(b => b.User.Role).ToList();
            return blogs;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await context.Blogs.Include(b => b.User.Role).ToListAsync();
        }

        public void Update(Blog blog)
        {
            context.Entry(blog).State = EntityState.Modified;
        }
    }
}
