using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.ExpensesDTO
{
    public class ExpensesByOwnerDTO
    {
        public string ownerId { get; set; }
        public int numberOfDaysToShow { get; set; }
    }
}
