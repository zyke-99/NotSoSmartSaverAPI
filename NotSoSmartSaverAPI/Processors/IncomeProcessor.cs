using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using NotSoSmartSaverWFA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Processors
{
    public class IncomeProcessor : IIncomeProcessor
    {
        public bool AddIncome(NewIncomeDTO data)
        {
            throw new NotImplementedException();
        }

        public List<Income> GetAllIncomes(GetAllDTO data)
        {
            throw new NotImplementedException();
        }

        public List<IncomeSumByOwnerDTO> GetSumOfIncomesByOwner(IncomesByOwnerDTO data)
        {
            throw new NotImplementedException();
        }

        public bool ModifyIncome(NewIncomeDTO data)
        {
            throw new NotImplementedException();
        }

        public bool RemoveIncome(string incomeId)
        {
            throw new NotImplementedException();
        }
    }
}
