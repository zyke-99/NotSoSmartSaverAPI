using NotSoSmartSaverWFA.DataAccess;
using NotSoSmartSaverWFA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSmartSaverWFA
{
    public class VeryTemporary
    {

        public static double getMoney(User user, string ownerId)
        {
            IExpensesProcessor exc = new ExpensesProcessor();
            IIncomeProcessor inc = new IncomeProcessor();
            var allExpenses = exc.getExpenses(ownerId);
            var allIncomes = inc.getIncomes(ownerId);
            var expensesSum = allExpenses.Sum(x => x.moneyUsed);
            var incomesSum = allIncomes.Sum(x => x.moneyReceived);
            return incomesSum - expensesSum;
        }
    }
}
