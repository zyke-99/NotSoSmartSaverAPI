using NotSoSmartSaverAPI.DTO.GroupsDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IGroupProcessor
    {

        public bool AddUserToGroup(AddUserToGroupDTO data);

        public bool CreateGroup(NewGroupDTO data);

        //public List<Groups> GetGroups(User user); ---GALIMAI REIKIA NAUJO DTO, KURIS SAVYJE TURETU USERID
        //BTW, TA DTO SAUGOT PRIE GroupsDTO ----- VISIEM MODELIAM TURI BUTI SKIRTINGI DTO FOLDERIAI

        public List<Users> GetGroupUsers(GroupIdDTO data);

        public bool RemoveGroup(GroupIdDTO data);

        public bool RemoveUserFromGroup(RemoveUserFromGroupDTO data);

        public bool ModifyGroup(NewGroupDTO data);

    }
}
