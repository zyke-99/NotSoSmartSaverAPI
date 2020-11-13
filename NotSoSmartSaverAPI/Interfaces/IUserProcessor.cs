using NotSoSmartSaverWFA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSoSmartSaverWFA.DataAccess
{
    public interface IUserProcessor
    {
        User getUserByUserEmail(string userEmail);

        User getUserById(string userId);

        void removeUser(string userId);

        void modifyUser(string userId, string newUserName = "", string newUserLastName = "", string newUserEmail = "", double newUserMoney = 0);

        void changeUserPassword(string userId, string newUserPassword);

        void createNewUser(string userEmail, string userPassword, string userName, string userLastName);
    }
}
