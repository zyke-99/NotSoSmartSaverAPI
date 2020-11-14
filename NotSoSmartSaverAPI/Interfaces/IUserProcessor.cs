using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSoSmartSaverAPI.Interfaces
{ 
    public interface IUserProcessor
    {
        Users getUserByUserEmail(string userEmail);

        Users getUserById(UserIdDTO data);

        bool removeUser(UserIdDTO data);

        bool modifyUser(ModifyUserDTO data);

        bool changeUserPassword(ChangePasswordDTO data);

        bool createNewUser(NewUserDTO data);
    }
}
