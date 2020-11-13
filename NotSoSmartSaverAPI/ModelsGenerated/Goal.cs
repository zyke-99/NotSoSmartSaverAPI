using System;
using System.Collections.Generic;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class Goal
    {
        public string Ownerid { get; set; }
        public string Goalid { get; set; }
        public float Moneyrequired { get; set; }
        public float Moneyallocated { get; set; }
        public DateTime? Goaltime { get; set; }
        public DateTime? Goalexpectedtime { get; set; }
        public string Goalname { get; set; }
    }
}
