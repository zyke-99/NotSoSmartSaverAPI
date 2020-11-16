using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.BudgetDTO
{
    public class SingleBudgetDTO
    {
        public string category { get; set; }
        public float? limit { get; set; }
    }
}
