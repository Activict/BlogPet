using MyBlog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Blog> Blogs { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }

        void Save();
        void SaveAsync();
    }
}
