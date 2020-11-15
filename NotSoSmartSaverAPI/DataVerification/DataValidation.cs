using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DataVerification
{
    public class DataValidation
    {
        public static bool isExpenseValid(Expense expense)
        {
            return true;
        }

        public static bool isGoalValid(Goal goal)
        {
            return true;
        }

        public static bool isGroupValid(Groups group)
        {
            throw new NotImplementedException();
        }

        public static bool isIncomeValid(Income income)
        {
            return true;
        }

        public static bool isUserValid(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
