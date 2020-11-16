using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.UserDTO
{
    public class ChangePasswordDTO
    {
       public string userId { get; set; }
       public string userNewPassword { get; set; }
    }
}
