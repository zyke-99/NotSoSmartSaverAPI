using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class Expense
    {
        public string Ownerid { get; set; }
        public string Userid { get; set; }
        public string Expenseid { get; set; }

        [Required(ErrorMessage = "An amount has to be entered")]
        public float Moneyused { get; set; }
        public DateTime? Expensetime { get; set; }

        [Required(ErrorMessage = "An expense name has to be entered")]
        [MaxLength(30, ErrorMessage = "Expense name is too long, maximum lenght is  30")]
        public string Expensename { get; set; }

        [Required(ErrorMessage = "A category needs to be selected")]
        public int? Expensecategory { get; set; }
    }
}
