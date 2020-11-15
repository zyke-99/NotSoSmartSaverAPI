using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using NotSoSmartSaverAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI
{
    public class VeryTemporary
    {
        public static double getMoney(Users user, string ownerIdd)
        {
            IExpensesProcessor exc = new ExpenseProcessor();
            IIncomeProcessor inc = new IncomeProcessor();
            var allExpenses = exc.GetExpenses(new GetExpensesDTO
            {
                ownerId = ownerIdd,
                maxNumberOfExpensesToShow = -1,
                numberOfDaysToShow = -1

            });
            var allIncomes = inc.GetAllIncomes(new GetAllDTO
            {
                ownerId = ownerIdd,
                maxNumberOfIncomesToShow = -1,
                numberOfDaysToShow = -1
            });
            var expensesSum = allExpenses.Sum(x => x.Moneyused);
            var incomesSum = allIncomes.Sum(x => x.Moneyrecieved);
            return incomesSum - expensesSum;
        }
    }
}
