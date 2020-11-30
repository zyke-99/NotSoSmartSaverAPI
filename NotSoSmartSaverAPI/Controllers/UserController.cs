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
        public async Task<IActionResult> AddUser([FromBody] NewUserDTO data)
        {
            if (await Task.Run(() => _userProcessor.CreateNewUser(data)))
                return Ok("User Added");
            else
                return BadRequest("User with that email already exists!");
        }


        [HttpGet]
        
        public async Task<IActionResult> UserLogin( string email, string password)
        {
            UserLoginDTO data = new UserLoginDTO { email = email, password = password };
            if (await _userVerification.IsUserVerifiedAsync(data))
            {
                return Ok(Task.Run(() => _userProcessor.GetUserByUserEmail(data.email)));
            }
            else return BadRequest("Failed to log in");
        }

        [HttpPut("ModifyUser")]
        public async Task<IActionResult> ModifyUser ([FromBody]ModifyUserDTO data)
        {
            await Task.Run(() => _userProcessor.ModifyUser(data));
            return Ok("User has been modified");
        }


        [HttpDelete("{userID}")]

        public async Task<IActionResult> RemoveUser(string userID)
        {
            await Task.Run(() => _userProcessor.RemoveUser(userID));
            return Ok("User removed");

        }
    }
}
