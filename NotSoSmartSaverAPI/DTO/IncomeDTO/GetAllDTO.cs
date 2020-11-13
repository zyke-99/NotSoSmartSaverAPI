using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.IncomeDTO
{
    public class GetAllDTO
    {
        public string ownerId { get; set; }
        public int numberOfDaysToShow { get; set; }
        public int maxNumberOfIncomesToShow { get; set; }
    }
}
