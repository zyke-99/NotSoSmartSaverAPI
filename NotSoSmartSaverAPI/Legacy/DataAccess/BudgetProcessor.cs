
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace NotSoSmartSaverWFA.DataAccess
{
    //class BudgetProcessor : IBudgetProcessor

    //{
    //    string budgetDataPath = @"C:\Users\Lenovo\source\repos\NotSoSmartSaverAPI\NotSoSmartSaverAPI\Data\Budgets.json";

    //    public void createNewBudget(string ownerId)
    //    {
    //        if (File.Exists(budgetDataPath) == true)
    //        {
    //            string jsonR = File.ReadAllText(budgetDataPath);
    //            var budgetsList = JsonConvert.DeserializeObject<List<Budget>>(jsonR);
                
    //            foreach (var budget in budgetsList)
    //            {
    //                if (ownerId == budget.ownerId)
    //                    return;
    //            }
    //            var newBudget = new Budget(ownerId);
    //            budgetsList.Add(newBudget);
    //            var jsonW = JsonConvert.SerializeObject(budgetsList, Formatting.Indented);
    //            File.WriteAllText(budgetDataPath, jsonW);
    //        }
    //        else
    //        {
    //            var newBudget = new Budget(ownerId);
    //            var budgetsList = new List<Budget>();
    //            budgetsList.Add(newBudget);
    //            var jsonW = JsonConvert.SerializeObject(budgetsList, Formatting.Indented);
    //            File.WriteAllText(budgetDataPath, jsonW);
    //        }
    //    }

     

    //    public void modifyBudget(string ownerId, List<double> categoriesLimitValue)
    //    {
    //        if (File.Exists(budgetDataPath) == true)
    //        {
    //            string jsonR = File.ReadAllText(budgetDataPath);
    //            var budgetList = JsonConvert.DeserializeObject<List<Budget>>(jsonR);

    //            foreach (var budget in budgetList)
    //            {
    //                if (budget.ownerId == ownerId)
    //                {
    //                    budget.Food = categoriesLimitValue[0];
    //                    budget.Clothes = categoriesLimitValue[1];
    //                    budget.Leisure = categoriesLimitValue[2];
    //                    budget.Rent = categoriesLimitValue[3];
    //                    budget.Loan = categoriesLimitValue[4];
    //                    budget.Alcohol = categoriesLimitValue[5];
    //                    budget.Tobacco = categoriesLimitValue[6];
    //                    budget.Insurance = categoriesLimitValue[7];
    //                    budget.Car = categoriesLimitValue[8];
    //                    budget.Subscriptions = categoriesLimitValue[9];
    //                    budget.Goal = categoriesLimitValue[10];
    //                    budget.Other = categoriesLimitValue[11];
    //                }
    //            }
    //            var jsonW = JsonConvert.SerializeObject(budgetList, Formatting.Indented);
    //            File.WriteAllText(budgetDataPath, jsonW);
    //        }
            
    //    }


    //    public void removeBudget(string ownerId)
    //    {
    //        if (File.Exists(budgetDataPath) == true)
    //        {
    //            string jsonR = File.ReadAllText(budgetDataPath);
    //            var budgetsList = JsonConvert.DeserializeObject<List<Budget>>(jsonR);
    //            budgetsList.RemoveAll(x => x.ownerId.Equals(ownerId));
    //            var jsonW = JsonConvert.SerializeObject(budgetsList);
    //            File.WriteAllText(budgetDataPath, jsonW);
    //        }
    //    }

    //    public Budget getBudget(string ownerId)
    //    {
         
    //        if (File.Exists(budgetDataPath) == true)
    //        {
    //            string jsonR = File.ReadAllText(budgetDataPath);
    //            var bugetsList = JsonConvert.DeserializeObject<List<Budget>>(jsonR);
    //            foreach (var buget in bugetsList)
    //            {
    //                if (ownerId == buget.ownerId)
    //                {
    //                    return buget;
    //                }
    //            }
    //        }
    //        return null;
    //    }

    //    public List<Budget> getBudgets(string ownerId)
    //    {
    //        var budgetList = new List<Budget>();

    //        if (File.Exists(budgetDataPath) == true) //Checks if file exists
    //        {
    //            string json = File.ReadAllText(budgetDataPath);
    //            budgetList = JsonConvert.DeserializeObject<List<Budget>>(json);

    //            foreach (var budget in budgetList)
    //            {
    //                if (budget.ownerId == ownerId)
    //                {
    //                    budgetList.Add(budget);
    //                }
    //            }

    //        }

    //        return budgetList;
    //    }
    //}
}
