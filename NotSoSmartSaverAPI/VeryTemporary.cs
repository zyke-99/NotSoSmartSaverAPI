using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using NotSoSmartSaverAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI
{
    public class VeryTemporary
    {
        private readonly IExpensesProcessor exc;
        private readonly IIncomeProcessor inc;
        public VeryTemporary (IExpensesProcessor expensesProcessor, IIncomeProcessor incomeProcessor)
        {
            exc = expensesProcessor;
            inc = incomeProcessor;
        }
        public double getMoney(Users user, string ownerIdd)
        { 
           
        }
    }
}
