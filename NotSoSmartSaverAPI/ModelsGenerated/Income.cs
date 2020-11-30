using System;
using System.ComponentModel.DataAnnotations;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class Income
    {
        public string Ownerid { get; set; }
        public string Userid { get; set; }
        public string Incomeid { get; set; }

        [Required]
        public float Moneyrecieved { get; set; }
        public DateTime? Incometime { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Expense name is too long, maximum lenght is  30")]
        public string Incomename { get; set; }
    }
}
