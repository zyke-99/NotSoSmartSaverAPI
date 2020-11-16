using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using NotSoSmartSaverAPI.DTO.BudgetDTO;
using NotSoSmartSaverAPI.ModelsGenerated;

namespace NotSoSmartSaverAPI.Interfaces
{
    public interface IBudgetProcessor
    {
        public Budget getBudget(GetBudgetDTO data);
        public bool modifyBudget(ModifyBudgetDTO data);
        public bool createNewBudget(GetBudgetDTO data);
    }
}
