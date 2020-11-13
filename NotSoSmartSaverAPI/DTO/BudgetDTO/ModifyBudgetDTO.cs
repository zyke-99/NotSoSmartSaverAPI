using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.BudgetDTO
{
    public class ModifyBudgetDTO
    {
        public string ownerId { get; set; }
        public List<string> listOfValues { get; set; }
    }
}
