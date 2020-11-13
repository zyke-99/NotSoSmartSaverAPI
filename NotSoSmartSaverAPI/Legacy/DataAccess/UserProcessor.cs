using Newtonsoft.Json;
using NotSoSmartSaverWFA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NotSoSmartSaverWFA.DataAccess
{
    class UserProcessor : IUserProcessor
    {
        string path =  @"../../../Data/Users.json";

        public void changeUserPassword(string userId, string newUserPassword)
        {
            if (File.Exists(path) == true)
            {
                string jsonR = File.ReadAllText(path);
                var userList = JsonConvert.DeserializeObject<List<User>>(jsonR);

                foreach (var user in userList)
                {
                    if (user.userId == userId)
                    {
                        user.userPassword = newUserPassword;
                    }
                }

                string jsonW = JsonConvert.SerializeObject(userList, Formatting.Indented);
                File.WriteAllText(path, jsonW);
            }
        }

        public void createNewUser(string userEmail, string userPassword, string userName, string userLastName)
        {
            if (File.Exists(path) == true)
            {
                string jsonR = File.ReadAllText(path);
                var userList = JsonConvert.DeserializeObject<List<User>>(jsonR);
                var newUser = new User(Guid.NewGuid().ToString(), userEmail, userPassword, userName, userLastName);
                userList.Add(newUser);
                var jsonW = JsonConvert.SerializeObject(userList, Formatting.Indented);
                File.WriteAllText(path, jsonW);
            }
            else
            {
                var newUser = new User(Guid.NewGuid().ToString(), userEmail, userPassword, userName, userLastName);
                var userList = new List<User>();
                userList.Add(newUser);
                var jsonW = JsonConvert.SerializeObject(userList, Formatting.Indented);
                File.WriteAllText(path, jsonW);
            }
        }

        public User getUserById(string userId)
        {

                if (File.Exists(path) == true)
                {
                    string json = File.ReadAllText(path);
                    var userList = JsonConvert.DeserializeObject<List<User>>(json);

                    foreach (var user in userList)
                    {
                        if (user.userId == userId)
                        {
                            return user;
                        }
                    }
                }

                return null;

        }

        public User getUserByUserEmail(string userEmail)
        {

            if (File.Exists(path) == true)
            {
                string json = File.ReadAllText(path);
                var userList = JsonConvert.DeserializeObject<List<User>>(json);

                foreach (var user in userList)
                {
                    if (user.userEmail == userEmail)
                    {
                        return user;
                    }
                }
            }

            return null;
        }


        public void modifyUser(string userId, string newUserName = "", string newUserLastName = "", string newUserEmail = "", double newUserMoney = 0)
        {
            if (File.Exists(path) == true)
            {
                string jsonR = File.ReadAllText(path);
                var userList = JsonConvert.DeserializeObject<List<User>>(jsonR);

                foreach (var user in userList)
                {
                    if (user.userId == userId)
                    {
                        if (newUserName != "")
                            user.userName = newUserName;
                        if (newUserLastName != "")
                            user.userLastName = newUserLastName;
                        if (newUserEmail != "")
                            user.userEmail = newUserEmail;
                        user.userMoney = newUserMoney;
                    }
                }

                string jsonW = JsonConvert.SerializeObject(userList, Formatting.Indented);
                File.WriteAllText(path, jsonW);
            }
        }

        public void removeUser(string userId)
        {
            string jsonR = File.ReadAllText(path);
            var userList = JsonConvert.DeserializeObject<List<User>>(jsonR);
            userList.RemoveAll(x => x.userId.Equals(userId));
            var jsonW = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(path, jsonW);
        }
    }
}

