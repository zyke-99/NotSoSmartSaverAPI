using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.GoalDTO
{
    public class NewGoalDTO
    {
        public string ownerId { get; set; }
        public string goalName { get; set; }
        public float moneyRequired { get; set; }
        public DateTime goalExpectedTime { get; set; }
    }
}
