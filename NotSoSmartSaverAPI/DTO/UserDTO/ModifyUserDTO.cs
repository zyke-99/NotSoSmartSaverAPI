using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.UserDTO
{
    public class ModifyUserDTO
    {
        public string userId { get; set; }
        public string newUserName { get; set; }
        public string newUserEmail { get; set; }
        public float newUserMoney { get; set; }
    }
}
