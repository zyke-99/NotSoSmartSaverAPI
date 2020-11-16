using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSoSmartSaverAPI.Interfaces
{ 
    public interface IUserProcessor
    {
        Users GetUserByUserEmail(string userEmail);

        Users GetUserById(UserIdDTO data);

        bool RemoveUser(string userId);

        bool ModifyUser(ModifyUserDTO data);

        bool ChangeUserPassword(ChangePasswordDTO data);

        bool CreateNewUser(NewUserDTO data);
    }
}
