using System;
using System.Collections.Generic;
using ECommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok("Getting all users");
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid userId)
        {
            return Ok($"Getting user by ID {userId}");
        }
    }
}
