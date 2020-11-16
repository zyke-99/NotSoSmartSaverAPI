using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.GoalDTO
{
    public class CompleteGoalDTO
    {
        public string goalId { get; set; }
        public float moneyRequired { get; set; }
        public float moneyAllocated { get; set; }
    }
}
