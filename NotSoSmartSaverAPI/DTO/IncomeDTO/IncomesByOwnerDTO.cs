using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.IncomeDTO
{
    public class IncomesByOwnerDTO
    {
        public string ownerId { get; set; }
        public int numberOfDaysToShow { get; set; }
    }
}
