using AutoMapper;
using MyBlog.BLL.DTO.Account;
using MyBlog.BLL.Interfaces;
using MyBlog.DAL.Entities;
using MyBlog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uof;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uof = unitOfWork;
            this.mapper = mapper;
        }
        public void Create(UserDTO userDTO)
        {
            User user = mapper.Map<User>(userDTO);
            uof.Users.Create(user);
            uof.Save();
        }

        public void Delete(int id)
        {
            uof.Users.Delete(id);
            uof.Save();
        }
        public void Edit(UserDTO userDTO)
        {
            User user = uof.Users.Get(userDTO.Id);
            if (user == null) return;

            user = mapper.Map<User>(userDTO);

            uof.Users.Update(user);
            uof.SaveAsync();
        }

        public UserDTO Get(int id)
        {
            User user = uof.Users.Get(id);
            return mapper.Map<UserDTO>(user);
        }

        public List<UserDTO> GetAll()
        {
            var usersDTO = new List<UserDTO>();
            var users = uof.Users.GetAll();

            users.ToList().ForEach(user => usersDTO.Add(mapper.Map<UserDTO>(user)));
            return usersDTO;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var usersDTO = new List<UserDTO>();
            var users = await uof.Users.GetAllAsync();

            users.ToList().ForEach(user => usersDTO.Add(mapper.Map<UserDTO>(user)));
            return usersDTO;
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            User user = await uof.Users.GetAsync(id);
            return mapper.Map<UserDTO>(user);
        }

        public void Dispose()
        {
            uof.Dispose();
        }
    }
}
