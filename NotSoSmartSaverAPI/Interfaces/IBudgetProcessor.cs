using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using NotSoSmartSaverAPI.DTO.BudgetDTO;
using NotSoSmartSaverAPI.ModelsGenerated;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IBudgetProcessor
    {
        public Task<List<SingleBudgetDTO>> getBudget(GetBudgetDTO data);
        public Task<bool> modifyBudget(ModifyBudgetDTO data);
        public Task<bool> createNewBudget(GetBudgetDTO data);
    }
}
