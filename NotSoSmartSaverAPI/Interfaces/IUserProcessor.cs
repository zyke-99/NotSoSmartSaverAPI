using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Interfaces
{ 
    public interface IUserProcessor
    {
        Task<Users> GetUserByUserEmail(string userEmail);

        Task<Users> GetUserById(UserIdDTO data);

        Task<bool> RemoveUser(string userId);

        Task<bool> ModifyUser(ModifyUserDTO data);

        Task<bool> ChangeUserPassword(ChangePasswordDTO data);

        Task<bool> CreateNewUser(NewUserDTO data);
    }
}
