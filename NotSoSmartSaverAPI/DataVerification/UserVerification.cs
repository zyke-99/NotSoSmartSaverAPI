using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using NotSoSmartSaverAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DataVerification
{
    public class UserVerification
    {
        public static bool isUserVerified(Users user)
        {
            IUserProcessor u = new UserProcessor();
            Users tempUser = u.getUserByUserEmail(user.Useremail);
            if (tempUser == null) return false;
            else
            {
                if (tempUser.Userpassword == user.Userpassword) return true;
                else return false;
            }
            //Should check if user is legit. To do so, use
            //the UserProccessor to getUserByEmail and check if the passwords match. If they do, return true,
            //else - return false
        }
    }
}
