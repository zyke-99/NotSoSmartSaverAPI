using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.DTO.UserDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IExpensesProcessor
    {

        public Task<bool> AddExpense(NewExpenseDTO data);

        public Task<List<Expense>> GetExpenses(GetExpensesDTO data);

        public Task<List<SumByCatDTO>> GetSumOfExpensesByCategory(ExpensesByOwnerDTO data);

        public Task<List<SumByOwnerDTO>> GetSumOfExpensesByOwner(ExpensesByOwnerDTO data);

        public Task<bool> RemoveExpense(string expenseId);

        public Task<bool> ModifyExpense(NewExpenseDTO data);
      
        public Task<float> getUserMoneyAsync(UserIdDTO data);
    }
}
