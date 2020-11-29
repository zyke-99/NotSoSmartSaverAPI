using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.DTO.IncomeDTO
{
    public class NewIncomeDTO
    {
        public string ownerId { get; set; }
        public string userId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Income name is too long, maximum lenght is  30")]
        public string incomeName { get; set; }

        [Required(ErrorMessage = "An amount has to be put in")]
        public double moneyReceived { get; set; }
    }
}
