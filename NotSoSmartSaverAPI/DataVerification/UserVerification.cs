using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using NotSoSmartSaverAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DataVerification
{
    public class UserVerification : IUserVerification
    {
        IUserProcessor usp;
        public UserVerification (IUserProcessor userProcessor)
        {
            usp = userProcessor;
        }
        public async Task<bool> IsUserVerifiedAsync(UserLoginDTO user)
        {
            
            Users tempUser = await usp.GetUserByUserEmail(user.email);
            if (tempUser == null) return false;
            else
            {
                if (tempUser.Userpassword == user.password) return true;
                else return false;
            }
            //Should check if user is legit. To do so, use
            //the UserProccessor to getUserByEmail and check if the passwords match. If they do, return true,
            //else - return false
        }
    }
}
