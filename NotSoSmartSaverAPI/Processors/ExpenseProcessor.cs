using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;

namespace NotSoSmartSaverAPI.Processors
{
    public class ExpenseProcessor : IExpensesProcessor
    {
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
            var listOfExpenses = context.Expense.Where(a => a.Ownerid == data.ownerId).ToList();
            return listOfExpenses;
        }

        public List<SumByCatDTO> GetSumOfExpensesByCategory(ExpensesByOwnerDTO data)
        {
            throw new NotImplementedException();
        }

        public List<SumByOwnerDTO> GetSumOfExpensesByOwner(ExpensesByOwnerDTO data)
        {
            throw new NotImplementedException();
        }

        public bool ModifyExpense(NewExpenseDTO data)
        {
            NSSSContext context = new NSSSContext();
            var expense = context.Expense.First(a => a.Ownerid == data.ownerId);
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
