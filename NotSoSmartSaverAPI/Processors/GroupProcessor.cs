using NotSoSmartSaverAPI.DTO.GroupsDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Processors
{
    public class GroupProcessor : IGroupProcessor
    {
        public bool AddUserToGroup(AddUserToGroupDTO data)
        {
            throw new NotImplementedException();
        }

        public bool CreateGroup(NewGroupDTO data)
        {
            NSSSContext context = new NSSSContext();
            Groups group = new Groups
            {
                Groupid = Guid.NewGuid().ToString(),
                Groupmoney = 0,
                Groupname = data.groupName
            };
            return true;
        }

        public List<Users> GetGroupUsers(GroupIdDTO data)
        {
            throw new NotImplementedException();
        }

        public bool ModifyGroup(NewGroupDTO data)
        {
            throw new NotImplementedException();
        }

        public bool RemoveGroup(GroupIdDTO data)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserFromGroup(RemoveUserFromGroupDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
