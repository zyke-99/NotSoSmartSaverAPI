using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.ExpensesDTO
{
    public class ModifyExpenseDTO
    {
        public string expenseId { get; set; }
        public string expenseName { get; set; }
        public float moneyUsed { get; set; }
        public CategoryEnum expenseCategory { get; set; }
    }
}
