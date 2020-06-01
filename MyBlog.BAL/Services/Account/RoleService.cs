using AutoMapper;
using MyBlog.BLL.DTO.Account;
using MyBlog.BLL.Interfaces.Account;
using MyBlog.DAL.Entities;
using MyBlog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uof;
        private readonly IMapper mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uof = unitOfWork;
            this.mapper = mapper;
        }
        public void Create(RoleDTO roleDTO)
        {
            Role role = mapper.Map<Role>(roleDTO);
            uof.Roles.Create(role);
            uof.Save();
        }

        public void Delete(int id)
        {
            uof.Roles.Delete(id);
            uof.Save();
        }

        public void Edit(RoleDTO roleDTO)
        {
            Role role = uof.Roles.Get(roleDTO.Id);
            if (role == null) return;
            
            role.Id = roleDTO.Id;
            role.Name = roleDTO.Name;

            uof.Roles.Update(role);
            uof.SaveAsync();
        }

        public RoleDTO Get(int id)
        {
            Role role = uof.Roles.Get(id);
            if (role == null) return null;

            return mapper.Map<RoleDTO>(role);
        }

        public List<RoleDTO> GetAll()
        {
            var rolesDTO = new List<RoleDTO>();
            var roles = uof.Roles.GetAll();

            roles.ToList().ForEach(role => rolesDTO.Add(mapper.Map<RoleDTO>(role)));
            return rolesDTO;
        }

        public async Task<List<RoleDTO>> GetAllAsync()
        {
            var rolesDTO = new List<RoleDTO>();
            var roles = await uof.Roles.GetAllAsync();

            roles.ToList().ForEach(role => rolesDTO.Add(mapper.Map<RoleDTO>(role)));
            return rolesDTO;
        }

        public async Task<RoleDTO> GetAsync(int id)
        {
            Role role = await uof.Roles.GetAsync(id);
            if (role == null) return null;

            return mapper.Map<RoleDTO>(role);
        }

        public void Dispose()
        {
            uof.Dispose();
        }
    }
}
