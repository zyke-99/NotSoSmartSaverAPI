using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using NotSoSmartSaverWFA.Models;

namespace NotSoSmartSaverWFA.DataAccess
{
    public interface IBudgetProcessor
    {
        public Budget getBudget(string ownerId);
        public List<Budget> getBudgets(string ownerId);

        public void removeBudget(string budgetId);

        public void modifyBudget(string ownerId, List<double> categoriesLimitValue);

        public void createNewBudget(string ownerId);
    }
}
