using NotSoSmartSaverAPI.DTO.GroupsDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IGroupProcessor
    {

        public Task<bool> AddUserToGroup(AddUserToGroupDTO data);

        public Task<bool> CreateGroup(NewGroupDTO data);

        public Task<List<Groups>> GetGroups(GetUserGroupsDTO data);
        //BTW, TA DTO SAUGOT PRIE GroupsDTO ----- VISIEM MODELIAM TURI BUTI SKIRTINGI DTO FOLDERIAI

        public Task<List<Users>> GetGroupUsers(GroupIdDTO data);

        public Task<bool> RemoveGroup(GroupIdDTO data);

        public Task<bool> RemoveUserFromGroup(RemoveUserFromGroupDTO data);

        public Task<bool> ModifyGroup(ModifyGroupDTO data);

    }
}
