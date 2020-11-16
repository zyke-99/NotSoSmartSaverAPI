using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IExpensesProcessor
    {

        public bool AddExpense(NewExpenseDTO data);

        public List<Expense> GetExpenses(GetExpensesDTO data);

        public List<SumByCatDTO> GetSumOfExpensesByCategory(ExpensesByOwnerDTO data);

        public List<SumByOwnerDTO> GetSumOfExpensesByOwner(ExpensesByOwnerDTO data);

        public bool RemoveExpense(string expenseId);

        public bool ModifyExpense(NewExpenseDTO data);
    }
}
