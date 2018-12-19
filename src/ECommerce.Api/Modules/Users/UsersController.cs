using System;
using System.Collections.Generic;
using AutoMapper;
using ECommerce.Core.Managers.Users;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;

        public UsersController(IUserManager userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var users = this.userManager.GetUsers();
            var usersDto = this.mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUserById(Guid id)
        {
            var user = this.userManager.GetUserById(id);
            var userDto = this.mapper.Map<UserDTO>(user);

            return Ok(userDto);
        }
    }
}
