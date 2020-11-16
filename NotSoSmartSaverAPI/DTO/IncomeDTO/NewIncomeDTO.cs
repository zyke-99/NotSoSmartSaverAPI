using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.IncomeDTO
{
    public class NewIncomeDTO
    {
        public string ownerId { get; set; }
        public string userId { get; set; }
        public string incomeName { get; set; }
        public double moneyReceived { get; set; }
    }
}
