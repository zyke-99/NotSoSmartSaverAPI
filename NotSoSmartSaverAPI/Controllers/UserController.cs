using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.Interfaces;

namespace NotSoSmartSaverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProcessor _userProcessor;

        public UserController(IUserProcessor userProcessor)
        {
            _userProcessor = userProcessor;
        }

        [HttpPost]
        public IActionResult AddUser(NewUserDTO data)
        {
            if (_userProcessor.createNewUser(data))
                return Ok("User Added");
            else
                return BadRequest("User with that email already exists!");
        }
    }
}
