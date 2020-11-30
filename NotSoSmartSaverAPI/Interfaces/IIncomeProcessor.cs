using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IIncomeProcessor
    {
        public Task<List<Income>> GetAllIncomes(GetAllDTO data);

        public Task<List<IncomeSumByOwnerDTO>> GetSumOfIncomesByOwner(IncomesByOwnerDTO data);

        public Task<string> AddIncome(NewIncomeDTO data);

        public Task<bool> RemoveIncome(string incomeId);

        public Task<bool> ModifyIncome(NewIncomeDTO data);
    }
}
