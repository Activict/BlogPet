using AutoMapper;
using MyBlog.BLL.DTO;
using MyBlog.BLL.DTO.Account;
using MyBlog.DAL.Entities;

namespace MyBlog.Web.Services
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(userDTO => userDTO.RoleDTOId, user => user.MapFrom(user => user.RoleId))
                .ForMember(userDTO => userDTO.RoleDTO, user => user.MapFrom(user => user.Role))
                .ReverseMap();

            CreateMap<Blog, BlogDTO>()
                .ForMember(blogDTO => blogDTO.UserDTOId, blog => blog.MapFrom(blog => blog.UserId))
                .ForMember(blogDTO => blogDTO.UserDTO, blog => blog.MapFrom(blog => blog.User))
                .ReverseMap();
        }
    }
}
