using System;
using System.Collections.Generic;
using System.Net;
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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<UserDTO>))]
        public IActionResult GetUsers()
        {
            var users = this.userManager.GetUsers();
            var usersDto = this.mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDTO))]
        public IActionResult GetUserById(Guid id)
        {
            var user = this.userManager.GetUserById(id);
            var userDto = this.mapper.Map<UserDTO>(user);

            return Ok(userDto);
        }
    }
}
