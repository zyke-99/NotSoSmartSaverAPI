using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;

namespace NotSoSmartSaverAPI.Processors
{
    public class ExpenseProcessor : IExpensesProcessor
    {
        private readonly IUserProcessor usp;
        private readonly IIncomeProcessor inc;
        public ExpenseProcessor(IUserProcessor userProcessor, IIncomeProcessor incomeProcessor)
        {
            usp = userProcessor;
            inc = incomeProcessor;
        }
        public bool AddExpense(NewExpenseDTO data)
        {
            var expense = new Expense
            {
                Ownerid = data.ownerId,
                Userid = data.userId,
                Expenseid = Guid.NewGuid().ToString(),
                Moneyused = data.moneyUsed,
                Expensetime = DateTime.Now,
                Expensename = data.expenseName,
                Expensecategory = (int)data.expenseCategory
            };
            NSSSContext context = new NSSSContext();
            context.Expense.Add(expense);
            context.SaveChanges();
            return true;
        }

        public List<Expense> GetExpenses(GetExpensesDTO data)
        {
            NSSSContext context = new NSSSContext();
            List<Expense> listOfExpenses ;
            if (data.numberOfDaysToShow < 0)
            {
                if (data.maxNumberOfExpensesToShow < 0)
                {
                    listOfExpenses = context.Expense.Where(a => a.Ownerid == data.ownerId).ToList();
                }
                else
                    listOfExpenses = context.Expense.Where(a => a.Ownerid == data.ownerId).OrderBy(a => a.Expensetime).Take(data.maxNumberOfExpensesToShow).ToList();
            }
            else
            {
                if (data.maxNumberOfExpensesToShow < 0)
                {
                    listOfExpenses = context.Expense.Where(a => a.Ownerid == data.ownerId && a.Expensetime > DateTime.Now.AddDays(-data.numberOfDaysToShow)).ToList();
                }
                else
                    listOfExpenses = context.Expense.Where(a => a.Ownerid == data.ownerId && a.Expensetime > DateTime.Now.AddDays(-data.numberOfDaysToShow)).OrderBy(a => a.Expensetime).Take(data.maxNumberOfExpensesToShow).ToList();
            }
            return listOfExpenses;
        }

        public List<SumByCatDTO> GetSumOfExpensesByCategory(ExpensesByOwnerDTO data)
        {
            List<SumByCatDTO> catSums = new List<SumByCatDTO>();
            List<Expense> expenses = GetExpenses(new GetExpensesDTO { ownerId = data.ownerId, numberOfDaysToShow = data.numberOfDaysToShow, maxNumberOfExpensesToShow = -1});
            foreach (CategoryEnum e in Enum.GetValues(typeof(CategoryEnum)))
            {
                float sum = 0;
                foreach (var expense in expenses)
                {
                    if (expense.Expensecategory == (int) e && expense.Expensetime >= DateTime.Now.AddDays(-data.numberOfDaysToShow))
                    {
                        sum += expense.Moneyused;
                    }
                    else if (expense.Expensecategory == (int) e && data.numberOfDaysToShow == -1)
                    {
                        sum += expense.Moneyused;
                    }
                }
                SumByCatDTO tuple = new SumByCatDTO
                {
                    category = Enum.GetName(typeof(CategoryEnum), e),
                    sum = sum
                };
                catSums.Add(tuple);
            }
            return catSums;
        }

        public List<SumByOwnerDTO> GetSumOfExpensesByOwner(ExpensesByOwnerDTO data)
        {
            GetExpensesDTO data2 = new GetExpensesDTO();
            data2.ownerId = data.ownerId;
            data2.numberOfDaysToShow = data.numberOfDaysToShow;
            data2.maxNumberOfExpensesToShow = -1;

            List<Expense> listOfExpenses = GetExpenses(data2);
            List<SumByOwnerDTO> modifiedExpenses = listOfExpenses.
                GroupBy(e => e.Userid).
                Select(ce => new SumByOwnerDTO
                {
                    userName = usp.GetUserById(new UserIdDTO { userId = ce.First().Userid }).Username,
                    sum = ce.Sum(e => e.Moneyused)
                }).ToList();
            return modifiedExpenses;
        }

        public float getUserMoney(UserIdDTO data)
        {
           
            
                var allExpenses = GetExpenses(new GetExpensesDTO
                {
                    ownerId = data.userId,
                    maxNumberOfExpensesToShow = -1,
                    numberOfDaysToShow = -1

                });
                var allIncomes = inc.GetAllIncomes(new GetAllDTO
                {
                    ownerId = data.userId,
                    maxNumberOfIncomesToShow = -1,
                    numberOfDaysToShow = -1
                });
                var expensesSum = allExpenses.Sum(x => x.Moneyused);
                var incomesSum = allIncomes.Sum(x => x.Moneyrecieved);
                return incomesSum - expensesSum;
            
        }

        public bool ModifyExpense(ModifyExpenseDTO data)
        {
            NSSSContext context = new NSSSContext();
            var expense = context.Expense.First(a => a.Expenseid == data.expenseId);
            expense.Expensename = data.expenseName;
            expense.Expensecategory = (int) data.expenseCategory;
            expense.Moneyused = data.moneyUsed;
            context.SaveChanges();
            return true;
        }

        public bool RemoveExpense(string expenseId)
        {
            NSSSContext context = new NSSSContext();
            context.Remove(context.Expense.Single(a => a.Expenseid == expenseId));
            context.SaveChanges();
            return true;
        }
    }
}
