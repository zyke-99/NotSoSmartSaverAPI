using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.GroupsDTO
{
    public class RemoveUserFromGroupDTO
    {
        public string userId { get; set; }
        public string groupId { get; set; }
    }
}
