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
        NSSSContext context = new NSSSContext();
        public UserProcessor (IBudgetProcessor budgetProcessor)
        {
            bup = budgetProcessor;
        }
        public bool ChangeUserPassword(ChangePasswordDTO data)
        {
            Users user = context.Users.Find(data.userId);
            user.Userpassword = data.userNewPassword;
            context.SaveChanges();
            return true;
        }

        public bool CreateNewUser(NewUserDTO data)
        {
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

        public Users GetUserById(UserIdDTO data)
        {
            return context.Users.Find(data.userId);

        }

        public Users GetUserByUserEmail(string userEmail)
        {
            return context.Users.First(a => a.Useremail == userEmail);
        }

        public bool ModifyUser(ModifyUserDTO data)
        {
            Users user = context.Users.Find(data.userId);
            user.Useremail = data.newUserEmail;
            user.Username = data.newUserName;
            user.Usermoney = data.newUserMoney;
            context.SaveChanges();
            return true;
        }

        public bool RemoveUser(string userId)
        {
            context.Remove(context.Users.Find(userId));
            context.SaveChanges();
            return true;
        }
    }
}

