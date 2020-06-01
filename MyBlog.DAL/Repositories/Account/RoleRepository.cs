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
    public class RoleRepository : IRepository<Role>
    {
        private readonly DataContext context;

        public RoleRepository(DataContext context)
        {
            this.context = context;
        }
        public void Create(Role role)
        {
            context.Roles.Add(role);
        }

        public void Delete(int id)
        {
            Role role = context.Roles.Find(id);
            if (role != null)
            {
                context.Roles.Remove(role);
            }
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return context.Roles.Where(predicate);
        }

        public Role Get(int id)
        {
            return context.Roles.Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return context.Roles.ToList();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await context.Roles.FindAsync(id);
        }

        public void Update(Role role)
        {
            context.Entry(role).State = EntityState.Modified;
        }
    }
}
