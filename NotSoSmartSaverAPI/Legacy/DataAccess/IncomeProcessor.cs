using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NotSoSmartSaverAPI.ModelsGenerated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace NotSoSmartSaverWFA.DataAccess
{
    //class IncomeProcessor : IIncomeProcessor
    //{
    //    string incomeDataPath = @"C:\Users\Lenovo\source\repos\NotSoSmartSaverAPI\NotSoSmartSaverAPI\Data\Incomes.json";

    //    public List<Income> getIncomes(string ownerId)
    //    {
    //        var userIncomeList = new List<Income>();

    //        if(File.Exists(incomeDataPath) == true)
    //        {
    //            string json = File.ReadAllText(incomeDataPath);
    //            var incomeList = JsonConvert.DeserializeObject<List<Income>>(json);
    //            foreach (var income in incomeList)
    //            {
    //                if(income.ownerId == ownerId)
    //                {
    //                    userIncomeList.Add(income);
    //                }
    //            }
    //        }

    //        return userIncomeList;
    //    }

    //    public void modifyIncome(string incomeId, string newIncomeName, double newMoneyReceived)
    //    {
    //        if(File.Exists(incomeDataPath) == true)
    //        {
    //            string jsonR = File.ReadAllText(incomeDataPath);
    //            var incomeList = JsonConvert.DeserializeObject<List<Income>>(jsonR); 

    //            foreach (var income in incomeList)
    //            {
    //                if(income.incomeId == incomeId)
    //                {
    //                    income.incomeName = newIncomeName;
    //                    income.moneyReceived = newMoneyReceived;
    //                }
    //            }

    //            var jsonW = JsonConvert.SerializeObject(incomeList, Formatting.Indented);
    //            File.WriteAllText(incomeDataPath, jsonW);
    //        }
    //    }

    //    public void newIncome(string ownerId, string userId, string incomeName, double moneyReceived)
    //    {
    //        if(File.Exists(incomeDataPath) == true)
    //        {
    //            string jsonR = File.ReadAllText(incomeDataPath);
    //            var incomeList = JsonConvert.DeserializeObject<List<Income>>(jsonR);
    //            var newIncome = new Income(Guid.NewGuid().ToString(), ownerId, userId, incomeName, moneyReceived, DateTime.Now);
    //            DbContext context = new NSSSContext();
    //            var newinc = new NotSoSmartSaverAPI.ModelsGenerated.Income{ Userid = userId, Ownerid = ownerId, Incomeid = Guid.NewGuid().ToString(), Incometime = DateTime.Now, Incomename = incomeName };                
    //            context.Add(newinc);
    //            context.SaveChanges();
    //            incomeList.Add(newIncome);
    //            var jsonW = JsonConvert.SerializeObject(incomeList, Formatting.Indented);
    //            File.WriteAllText(incomeDataPath, jsonW);
    //        }
    //        else
    //        {
    //            var incomeList = new List<Income>();
    //            var newIncome = new Income(Guid.NewGuid().ToString(), ownerId, userId, incomeName, moneyReceived, DateTime.Now);
    //            incomeList.Add(newIncome);
    //            var jsonW = JsonConvert.SerializeObject(incomeList, Formatting.Indented);
    //            File.WriteAllText(incomeDataPath, jsonW);
    //        }
    //    }

    //    public void removeIncome(string incomeId)
    //    {
    //        if(File.Exists(incomeDataPath) == true)
    //        {
    //            string jsonR = File.ReadAllText(incomeDataPath);
    //            var incomeList = JsonConvert.DeserializeObject<List<Income>>(jsonR);
    //            incomeList.RemoveAll(x => x.incomeId.Equals(incomeId));
    //            var jsonW = JsonConvert.SerializeObject(incomeList, Formatting.Indented);
    //            File.WriteAllText(incomeDataPath, jsonW);
    //        }
    //    }
    //}
}
