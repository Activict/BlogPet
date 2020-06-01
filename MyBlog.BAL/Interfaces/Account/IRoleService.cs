using MyBlog.BLL.DTO.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.BLL.Interfaces.Account
{
    public interface IRoleService
    {
        void Create(RoleDTO role);
        void Delete(int id);
        void Edit(RoleDTO role);
        RoleDTO Get(int id);
        Task<RoleDTO> GetAsync(int id);
        List<RoleDTO> GetAll();
        Task<List<RoleDTO>> GetAllAsync();
        void Dispose();
    }
}
