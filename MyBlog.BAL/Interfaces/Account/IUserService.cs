using MyBlog.BLL.DTO.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.BLL.Interfaces
{
    public interface IUserService
    {
        void Create(UserDTO user);
        void Delete(int id);
        void Edit(UserDTO user);
        UserDTO Get(int id);
        Task<UserDTO> GetAsync(int id);
        List<UserDTO> GetAll();
        Task<List<UserDTO>> GetAllAsync();
        void Dispose();
    }
}
