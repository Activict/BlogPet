using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public Task<IEnumerable<T>> GetAllAsync();
        public T Get(int id);
        public Task<T> GetAsync(int id);
        public void Create(T obj);
        public void Update(T obj);
        public void Delete(int id);
        public IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
