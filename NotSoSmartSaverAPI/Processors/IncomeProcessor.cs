using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
//using NotSoSmartSaverWFA.DataAccess;
using NotSoSmartSaverAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NotSoSmartSaverAPI.Processors
{
    public class IncomeProcessor : IIncomeProcessor
    {
        public bool AddIncome(NewIncomeDTO data)
        {

            var newIncome = new Income {
                Incomeid = Guid.NewGuid().ToString(),
                Ownerid = data.ownerId, 
                Userid = data.userId, 
                Moneyrecieved = data.moneyReceived, 
                Incometime = DateTime.Now, 
                Incomename = data.incomeName};
            DbContext context = new NSSSContext();
            context.Add(newIncome);
            context.SaveChanges();
            return true;
        }

        public List<Income> GetAllIncomes(GetAllDTO data)
        {
            NSSSContext context = new NSSSContext();
            var listOfIncomes = context.Income.Where(a => a.Ownerid == data.ownerId && a.Incometime > DateTime.Now.AddDays(-data.numberOfDaysToShow)).OrderBy(a => a.Incometime).Take(data.maxNumberOfIncomesToShow).ToList();
            return listOfIncomes;
        }

        public List<IncomeSumByOwnerDTO> GetSumOfIncomesByOwner(IncomesByOwnerDTO data)
        {
            throw new NotImplementedException();
        }

        public bool ModifyIncome(NewIncomeDTO data)
        {
            NSSSContext context = new NSSSContext();
            var income = context.Income.First(a => a.Ownerid == data.ownerId);
            income.Incomename = data.incomeName;
            income.Moneyrecieved = data.moneyReceived;
            context.SaveChanges();
            return true;
        }

        public bool RemoveIncome(string incomeId)
        {
            NSSSContext context = new NSSSContext();
            context.Remove(context.Income.Single(a => a.Incomeid == incomeId));
            context.SaveChanges();
            return true;
        }
    }
}
