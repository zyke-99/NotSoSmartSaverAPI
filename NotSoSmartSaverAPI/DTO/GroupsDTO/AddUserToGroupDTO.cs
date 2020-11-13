using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.GroupsDTO
{
    public class AddUserToGroupDTO
    {
        public string groupId { get; set; }
        public string userEmail { get; set; }
    }
}
