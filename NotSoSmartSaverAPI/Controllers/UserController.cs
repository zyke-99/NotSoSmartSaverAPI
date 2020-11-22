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
        private readonly IUserVerification _userVerification;

        public UserController(IUserProcessor userProcessor, IUserVerification userVerification)
        {
            _userProcessor = userProcessor;
            _userVerification = userVerification;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] NewUserDTO data)
        {
            if (_userProcessor.CreateNewUser(data))
                return Ok("User Added");
            else
                return BadRequest("User with that email already exists!");
        }


        [HttpGet]
        
        public IActionResult UserLogin( string email, string password)
        {
            UserLoginDTO data = new UserLoginDTO { email = email, password = password };
            if (_userVerification.IsUserVerified(data))
            {
                return Ok(_userProcessor.GetUserByUserEmail(data.email));
            }
            else return BadRequest("Failed to log in");
        }

        [HttpPut("ModifyUser")]
        public IActionResult ModifyUser ([FromBody]ModifyUserDTO data)
        {
            _userProcessor.ModifyUser(data);
            return Ok("User has been modified");
        }


        [HttpDelete("{userID}")]

        public IActionResult RemoveUser(string userID)
        {
            _userProcessor.RemoveUser(userID);
            return Ok("User removed");

        }
    }
}
