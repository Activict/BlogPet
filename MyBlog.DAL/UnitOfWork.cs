using MyBlog.DAL.Entities;
using MyBlog.DAL.Interfaces;
using MyBlog.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly DataContext context;
        private BlogRepository blogRepository;
        private UserRepository userRepository;
        private RoleRepository roleRepository;

        public UnitOfWork()
        {
            context = new DataContext();
        }
        public IRepository<Blog> Blogs
        {
            get
            {
                blogRepository =  blogRepository ?? new BlogRepository(context);
                return blogRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                userRepository = userRepository ?? new UserRepository(context);
                return userRepository;
            }
        }
        public IRepository<Role> Roles
        {
            get
            {
                roleRepository = roleRepository ?? new RoleRepository(context);
                return roleRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public async void SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;

            if (disposing) context.DisposeAsync();
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
