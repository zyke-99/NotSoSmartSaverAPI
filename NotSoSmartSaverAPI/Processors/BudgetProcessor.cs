using NotSoSmartSaverAPI.DTO.BudgetDTO;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotSoSmartSaverAPI.Processors
{
    public class BudgetProcessor : IBudgetProcessor
    {
        public bool createNewBudget(GetBudgetDTO data)
        {
            NSSSContext context = new NSSSContext();
            Budget budget = new Budget
            {
                Ownerid = data.ownerId,
                Food = 0,
                Leisure = 0,
                Rent = 0,
                Loan = 0,
                Alcohol = 0,
                Tobacco = 0,
                Insurance = 0,
                Car = 0,
                Subscriptions = 0,
                Goal = 0,
                Other = 0,
                Clothes = 0
            };
            context.Budget.Add(budget);
            context.SaveChanges();
            return true;
        }

        public Budget getBudget(GetBudgetDTO data)
        {
            NSSSContext context = new NSSSContext();
            return context.Budget.First(a => a.Ownerid == data.ownerId);
        }

        public bool modifyBudget(ModifyBudgetDTO data)
        {
            NSSSContext context = new NSSSContext();
            var budget = context.Budget.Find(data.ownerId);
            budget.Food = float.Parse(data.listOfValues[0].Replace('.', ','));
            budget.Leisure = float.Parse(data.listOfValues[1].Replace('.', ','));
            budget.Rent = float.Parse(data.listOfValues[2].Replace('.', ','));
            budget.Loan = float.Parse(data.listOfValues[3].Replace('.', ','));
            budget.Alcohol = float.Parse(data.listOfValues[4].Replace('.', ','));
            budget.Tobacco = float.Parse(data.listOfValues[5].Replace('.', ','));
            budget.Insurance = float.Parse(data.listOfValues[6].Replace('.', ','));
            budget.Car = float.Parse(data.listOfValues[7].Replace('.', ','));
            budget.Subscriptions = float.Parse(data.listOfValues[8].Replace('.', ','));
            budget.Goal = float.Parse(data.listOfValues[9].Replace('.', ','));
            budget.Other = float.Parse(data.listOfValues[10].Replace('.', ','));
            context.SaveChanges();
            return true;
        }
    }
}
