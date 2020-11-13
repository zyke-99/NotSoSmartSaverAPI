using System;
using System.Collections.Generic;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class Expense
    {
        public string Ownerid { get; set; }
        public string Userid { get; set; }
        public string Expenseid { get; set; }
        public float Moneyused { get; set; }
        public DateTime? Expensetime { get; set; }
        public string Expensename { get; set; }
        public int? Expensecategory { get; set; }
    }
}
