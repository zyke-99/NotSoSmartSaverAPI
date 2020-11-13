using Newtonsoft.Json;
using NotSoSmartSaverWFA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NotSoSmartSaverWFA.DataAccess
{
    class GroupProcessor : IGroupProcessor
    {

        string groupDataPath = @"../../../Data/Groups.json";
        string userAndGroupDataPath = @"../../../Data/UserAndGroups.json";
        IUserProcessor usp = new UserProcessor();
        IBudgetProcessor bup = new BudgetProcessor();


        public void addUserToGroup(string groupId, string userId)
        {
             if (File.Exists(userAndGroupDataPath) == true)
            {
                string jsonR = File.ReadAllText(userAndGroupDataPath);
                var tupleList = JsonConvert.DeserializeObject<List<UserAndGroupTuple>>(jsonR);
                tupleList.Add(new UserAndGroupTuple(groupId, userId));
                var jsonW = JsonConvert.SerializeObject(tupleList, Formatting.Indented);
                File.WriteAllText(userAndGroupDataPath, jsonW);
            }
        }

        public void createNewGroup(string userId, string groupName)
        {
            if (File.Exists(groupDataPath) == true)
            {
                string groupId = Guid.NewGuid().ToString();
                string jsonR = File.ReadAllText(groupDataPath);
                var groupList = JsonConvert.DeserializeObject<List<Group>>(jsonR);
                var newGroup = new Group(groupId, groupName);
                groupList.Add(newGroup);
                var jsonW = JsonConvert.SerializeObject(groupList, Formatting.Indented);
                File.WriteAllText(groupDataPath, jsonW);
                jsonR = File.ReadAllText(userAndGroupDataPath);
                var tupleList = JsonConvert.DeserializeObject<List<UserAndGroupTuple>>(jsonR);
                if(tupleList == null)
                {
                    tupleList = new List<UserAndGroupTuple>();
                }
                tupleList.Add(new UserAndGroupTuple(groupId, userId));
                jsonW = JsonConvert.SerializeObject(tupleList, Formatting.Indented);
                File.WriteAllText(userAndGroupDataPath, jsonW);

                bup.createNewBudget(groupId);

            }
        }

        public List<Group> getUserGroups(string userId)
        {
            var neededGroupList = new List<Group>();

            if (File.Exists(userAndGroupDataPath) == true)
            {
                if(File.Exists(groupDataPath) == true)

                {
                    string json = File.ReadAllText(userAndGroupDataPath);
                    var tupleList = JsonConvert.DeserializeObject<List<UserAndGroupTuple>>(json);
                    if (tupleList != null)
                    {
                        tupleList = (
                        from pairs in tupleList
                        where pairs.userId == userId
                        select pairs).ToList();
                    }

                    json = File.ReadAllText(groupDataPath);

                    if (tupleList != null)
                    {
                        json = File.ReadAllText(groupDataPath);
                        var groupList = JsonConvert.DeserializeObject<List<Group>>(json);
                        neededGroupList = (
                            from g in groupList
                            join t in tupleList on g.groupId equals t.groupId
                            select g).ToList();
                      
                    }

                }
                

            }

            return neededGroupList;
        }

        public List<User> getUsersOfGroup(string groupId)
        {
            List<User> neededUsersList = new List<User>();
            if (File.Exists(userAndGroupDataPath) == true)
            {

                string jsonR = File.ReadAllText(userAndGroupDataPath);
                var tupleList = JsonConvert.DeserializeObject<List<UserAndGroupTuple>>(jsonR);
                tupleList = (
                    from t in tupleList
                    where t.groupId == groupId
                    select t).ToList();

                if(tupleList != null)
                {
                    foreach(var tuple in tupleList)
                    {
                        neededUsersList.Add(usp.getUserById(tuple.userId));
                    }
                }

            }

            return neededUsersList;
        }

        public void modifyGroupName(string groupId, string newGroupName)
        {
            if (File.Exists(groupDataPath) == true)
            {
                string jsonR = File.ReadAllText(groupDataPath);
                var groupList = JsonConvert.DeserializeObject<List<Group>>(jsonR);

                foreach (var group in groupList)
                {
                    if (group.groupId == groupId)
                    {
                        group.groupName = newGroupName;
                    }
                }

                string jsonW = JsonConvert.SerializeObject(groupList, Formatting.Indented);
                File.WriteAllText(groupDataPath, jsonW);
            }
        }

        public void removeGroup(string groupId)
        {
            string jsonR = File.ReadAllText(groupDataPath);
            var groupList = JsonConvert.DeserializeObject<List<Group>>(jsonR);
            groupList.RemoveAll(x => x.groupId.Equals(groupId));
            var jsonW = JsonConvert.SerializeObject(groupList, Formatting.Indented);
            File.WriteAllText(groupDataPath, jsonW);

            jsonR = File.ReadAllText(userAndGroupDataPath);
            var tupleList = JsonConvert.DeserializeObject<List<UserAndGroupTuple>>(jsonR);
            tupleList.RemoveAll(x => x.groupId.Equals(groupId));
            jsonW = JsonConvert.SerializeObject(tupleList, Formatting.Indented);
            File.WriteAllText(userAndGroupDataPath, jsonW);
        }

        public void removeUserFromGroup(string groupId, string userId)
        {
            if (File.Exists(userAndGroupDataPath) == true)
            {
                string jsonR = File.ReadAllText(userAndGroupDataPath);
                var tupleList = JsonConvert.DeserializeObject<List<UserAndGroupTuple>>(jsonR);
                tupleList.RemoveAll(x => (x.userId.Equals(userId) && x.groupId.Equals(groupId)));
                var jsonW = JsonConvert.SerializeObject(tupleList, Formatting.Indented);
                File.WriteAllText(userAndGroupDataPath, jsonW);
            }
        }
    }
}
