using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DataVerification
{
    public class DataValidation : IDataValidation
    {
        IExpensesProcessor exc;
        IIncomeProcessor inc;

        public DataValidation (IExpensesProcessor expensesProcessor, IIncomeProcessor incomeProcessor)
        {
            exc = expensesProcessor;
            inc = incomeProcessor;
        }
        public async Task<bool> isExpenseValidAsync(NewExpenseDTO expense)
        {
            var allExpenses = await exc.GetExpenses(new GetExpensesDTO
            {
                ownerId = expense.ownerId,
                maxNumberOfExpensesToShow = -1,
                numberOfDaysToShow = -1

            });
            var allIncomes = await inc.GetAllIncomes(new GetAllDTO
            {
                ownerId = expense.ownerId,
                maxNumberOfIncomesToShow = -1,
                numberOfDaysToShow = -1
            });
            var expensesSum = allExpenses.Sum(x => x.Moneyused);
            var incomesSum = allIncomes.Sum(x => x.Moneyrecieved);
            return incomesSum - expensesSum > expense.moneyUsed;
        }

        public bool isGoalValid(Goal goal)
        {
            throw new NotImplementedException();
        }

        public bool isGroupValid(Groups group)
        {
            throw new NotImplementedException();
        }

        public bool isIncomeValid(Income income)
        {
            throw new NotImplementedException();
        }

        public bool isUserValid(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
