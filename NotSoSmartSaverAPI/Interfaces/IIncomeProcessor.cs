using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IIncomeProcessor
    {
        public List<Income> GetAllIncomes(GetAllDTO data);

        public List<IncomeSumByOwnerDTO> GetSumOfIncomesByOwner(IncomesByOwnerDTO data);

        public bool AddIncome(NewIncomeDTO data);

        public bool RemoveIncome(string incomeId);

        public bool ModifyIncome(NewIncomeDTO data);
    }
}
