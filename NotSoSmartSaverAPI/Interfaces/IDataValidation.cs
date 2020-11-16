using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Interfaces
{
     public interface IDataValidation
    {
        bool isExpenseValid(NewExpenseDTO expense);
        bool isGoalValid(Goal goal);
        bool isIncomeValid(Income income);
        bool isGroupValid(Groups group);
        bool isUserValid(Users user);
    }
}
