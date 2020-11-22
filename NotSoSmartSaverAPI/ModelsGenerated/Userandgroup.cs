using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class Userandgroup
    {
        [Key]
        public string Groupid { get; set; }
        public string Userid { get; set; }
    }
}
