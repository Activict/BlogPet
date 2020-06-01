using Microsoft.EntityFrameworkCore;
using MyBlog.DAL.Entities;

namespace MyBlog.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESK\SQLEXPRESS;Database=blogDB;Trusted_Connection=True;");
        }
        public DataContext()
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
