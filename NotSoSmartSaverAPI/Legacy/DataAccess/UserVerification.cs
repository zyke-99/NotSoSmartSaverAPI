
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NotSoSmartSaverWFA.DataAccess.DataValidation
//{
//    class UserVerification : IUserVerification
//    {
//        public bool isUserVerified(User user)
//        {
//            IUserProcessor u = new UserProcessor();
//            User tempUser = u.getUserByUserEmail(user.userEmail);
//            if (tempUser == null) return false;
//            else
//            {
//                if (tempUser.userPassword == user.userPassword) return true;
//                else return false;
//            }
//            //Should check if user is legit. To do so, use
//            //the UserProccessor to getUserByEmail and check if the passwords match. If they do, return true,
//            //else - return false
//        }
//    }
//}
