using AutoMapper;
using ECommerce.Core.Entities;

namespace ECommerce.Api.Modules.Users
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            base.CreateMap<UserDTO, User>();
        }
    }
}
