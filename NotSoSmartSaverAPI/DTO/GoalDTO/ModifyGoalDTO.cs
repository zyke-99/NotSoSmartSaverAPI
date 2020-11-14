using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.GoalDTO
{
    public class ModifyGoalDTO
    {
       public string goalId { get; set; }
       public string newGoalName { get; set; }
       public float newMoneyRequired { get; set; }
        public DateTime newExpectedTime { get; set; }
    }
}
