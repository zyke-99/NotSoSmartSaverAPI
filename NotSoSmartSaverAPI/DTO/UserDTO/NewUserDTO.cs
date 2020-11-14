using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.UserDTO
{
    public class NewUserDTO
    {
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public string userName { get; set; }
        public string userLastName { get; set; }
    }
}
