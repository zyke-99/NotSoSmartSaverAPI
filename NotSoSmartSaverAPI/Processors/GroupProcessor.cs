using NotSoSmartSaverAPI.DTO.BudgetDTO;
using NotSoSmartSaverAPI.DTO.GroupsDTO;
using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Processors
{
    public class GroupProcessor : IGroupProcessor
    {
        private readonly IBudgetProcessor bup;
        private readonly IUserProcessor usp;
        public GroupProcessor (IBudgetProcessor budgetProcessor, IUserProcessor userProcessor)
        {
            bup = budgetProcessor;
            usp = userProcessor;
        }

        public Task<bool> AddUserToGroup(AddUserToGroupDTO data) => Task.Run(async () =>
        {
            NSSSContext context = new NSSSContext();
            context.Userandgroup.Add(new Userandgroup
            {
                Groupid = data.groupId,
                Userid = (await Task.Run(() => usp.GetUserByUserEmail(data.userEmail))).Userid
            });
            context.SaveChanges();
            return true;
        });

        public Task<bool> CreateGroup(NewGroupDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            Groups group = new Groups
            {
                Groupid = Guid.NewGuid().ToString(),
                Groupmoney = 0,
                Groupname = data.groupName
            };
            context.Groups.Add(group);
            Userandgroup tuple = new Userandgroup
            {
                Userid = data.userId,
                Groupid = group.Groupid
            };
            context.Userandgroup.Add(tuple);
            context.SaveChanges();
            bup.createNewBudget(new GetBudgetDTO { ownerId = group.Groupid });
            return true;
        });

        public async Task<List<Groups>> GetGroups(GetUserGroupsDTO data)
        {
            List<Groups> neededGroupList = new List<Groups>();
            NSSSContext context = new NSSSContext();
            List<Userandgroup> tupleList = await Task.Run(() => context.Userandgroup.Where(x => x.Userid == data.userId).ToList());
            List<Groups> groupsList = context.Groups.ToList();
            if (tupleList != null)
            {
                neededGroupList = (
                    from g in groupsList
                    join t in tupleList on g.Groupid equals t.Groupid
                    select g).ToList();
            }
            return neededGroupList;
        }

        public async Task<List<Users>> GetGroupUsers(GroupIdDTO data)
        {
            NSSSContext context = new NSSSContext();
            List<Users> neededUsersList = new List<Users>();
            List<Userandgroup> tupleList = await Task.Run(() => context.Userandgroup.Where(a => a.Groupid == data.groupId).ToList());
            if (tupleList != null)
            {
                foreach (var tuple in tupleList)
                {
                    neededUsersList.Add(await usp.GetUserById(new UserIdDTO
                    {
                        userId = tuple.Userid
                    }));
                }
            }
            return neededUsersList;
        }

        public Task<bool> ModifyGroup(ModifyGroupDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            Groups group = context.Groups.Find(data.groupId);
            group.Groupname = data.newName;
            context.SaveChanges();
            return true;
        });

        public Task<bool> RemoveGroup(GroupIdDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            context.Remove(context.Groups.Find(data.groupId));
            context.RemoveRange(context.Userandgroup.Where(x => x.Groupid == data.groupId));
            context.SaveChanges();
            return true;
        });

        public Task<bool> RemoveUserFromGroup(RemoveUserFromGroupDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            context.Userandgroup.Remove(context.Userandgroup.First(a => a.Userid == data.userId && a.Groupid == data.groupId));
            context.SaveChanges();
            return true;
        });
    }
}
