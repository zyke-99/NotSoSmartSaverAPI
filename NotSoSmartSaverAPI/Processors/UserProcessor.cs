using Microsoft.EntityFrameworkCore;
using NotSoSmartSaverAPI.DTO.BudgetDTO;
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
        public bool changeUserPassword(ChangePasswordDTO data)
        {
            NSSSContext context = new NSSSContext();
            Users user = context.Users.Find(data.userId);
            user.Userpassword = data.userNewPassword;
            context.SaveChanges();
            return true;
        }

        public bool createNewUser(NewUserDTO data)
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

        }

        public Users getUserById(UserIdDTO data)
        {
            NSSSContext context = new NSSSContext();
            return context.Users.Find(data.userId);

        }

        public Users getUserByUserEmail(string userEmail)
        {
            NSSSContext context = new NSSSContext();
            return context.Users.First(a => a.Useremail == userEmail);
        }

        public bool modifyUser(ModifyUserDTO data)
        {
            NSSSContext context = new NSSSContext();
            Users user = context.Users.Find(data.userId);
            user.Useremail = data.newUserEmail;
            user.Username = data.newUserName;
            user.Usermoney = data.newUserMoney;
            context.SaveChanges();
            return true;
        }

        public bool removeUser(UserIdDTO data)
        {
            NSSSContext context = new NSSSContext();
            context.Remove(context.Users.Find(data.userId));
            context.SaveChanges();
            return true;
        }
    }
}
