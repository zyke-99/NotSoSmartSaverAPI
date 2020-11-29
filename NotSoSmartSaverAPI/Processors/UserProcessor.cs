using Microsoft.EntityFrameworkCore;
using NotSoSmartSaverAPI.DTO.BudgetDTO;
using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Processors
{
    public class UserProcessor : IUserProcessor
    {

        private readonly IBudgetProcessor bup;
        public UserProcessor (IBudgetProcessor budgetProcessor)
        {
            bup = budgetProcessor;
        }
        public Task<bool> ChangeUserPassword(ChangePasswordDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            Users user = context.Users.Find(data.userId);
            user.Userpassword = data.userNewPassword;
            context.SaveChanges();
            return true;
        });

        public Task<bool> CreateNewUser(NewUserDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            Users user = new Users
            {
                Userid = Guid.NewGuid().ToString(),
                Usermoney = 0,
                Useremail = data.userEmail,
                Userlastname = data.userLastName,
                Username = data.userName,
                Userpassword = data.userPassword
            };
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                return false;
            }
            bup.createNewBudget(new GetBudgetDTO { ownerId = user.Userid });
            context.SaveChanges();
            return true;

        });

        public async Task<Users> GetUserById(UserIdDTO data)
        {
            NSSSContext context = new NSSSContext();
            return await Task.Run(() => context.Users.Find(data.userId));

        }

        public async Task<Users> GetUserByUserEmail(string userEmail)
        {
            NSSSContext context = new NSSSContext();
            return await Task.Run(() => context.Users.First(a => a.Useremail == userEmail));
        }

        public Task<bool> ModifyUser(ModifyUserDTO data) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            Users user = context.Users.Find(data.userId);
            user.Useremail = data.newUserEmail;
            user.Username = data.newUserName;
            user.Usermoney = data.newUserMoney;
            context.SaveChanges();
            return true;
        });

        public Task<bool> RemoveUser(string userId) => Task.Run(() =>
        {
            NSSSContext context = new NSSSContext();
            context.Remove(context.Users.Find(userId));
            context.SaveChanges();
            return true;
        });
    }
}
