using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class Groups
    {
        public string Groupid { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Group name is too long, maximum lenght is  30")]
        public string Groupname { get; set; }
        public float? Groupmoney { get; set; }
    }
}
