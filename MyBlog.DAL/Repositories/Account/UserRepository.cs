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
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext context;
        public UserRepository(DataContext context)
        {
            this.context = context;
        }
        public void Create(User user)
        {
            context.Add(user);
        }

        public void Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
            }
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return context.Users.Include(u => u.Role).Where(predicate).ToList();
        }

        public User Get(int id)
        {
            return context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.Include(u => u.Role).ToList();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}
