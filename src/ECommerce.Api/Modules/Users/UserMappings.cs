using AutoMapper;
using ECommerce.Core.Entities;

namespace ECommerce.Api.Modules.Users
{
    internal class UserMappings : Profile
    {
        public UserMappings()
        {
            base.CreateMap<User, UserDTO>();
            base.CreateMap<UserDTO, User>();
        }
    }
}
