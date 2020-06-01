using MyBlog.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.BLL.Interfaces
{
    public interface IBlogService
    {
        void Create(BlogDTO blog);
        void Delete(int id);
        void Edit(BlogDTO blog);
        BlogDTO Get(int id);
        Task<BlogDTO> GetAsync(int id);
        List<BlogDTO> GetAll();
        Task<List<BlogDTO>> GetAllAsync();
        Task<List<BlogDTO>> GetForPage(int skip, int take);
        void Dispose();
    }
}
