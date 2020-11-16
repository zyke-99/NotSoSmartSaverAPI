using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.GoalDTO
{
    public class AddMoneyDTO
    {
        public string userId { get; set; }
        public string goalId { get; set; }
        public string goalName { get; set; }
        public float moneyToAdd { get; set; }
        public float goalAllocatedMoney { get; set; }
        public float goalRequiredMoney { get; set; }
    }
}
