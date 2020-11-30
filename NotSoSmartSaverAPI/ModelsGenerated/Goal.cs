using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class Goal
    {
        public string Ownerid { get; set; }
        public string Goalid { get; set; }

        [Required(ErrorMessage = "A required amount has to be set")]
        public float Moneyrequired { get; set; }
        public float Moneyallocated { get; set; }
        public DateTime? Goaltime { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "A date has to be specified")]
        public DateTime? Goalexpectedtime { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Goal name is too long, maximum lenght is  100")]
        public string Goalname { get; set; }
    }
}
