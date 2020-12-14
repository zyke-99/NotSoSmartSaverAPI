using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
//using NotSoSmartSaverWFA.DataAccess;
using NotSoSmartSaverAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotSoSmartSaverAPI.DTO.UserDTO;

namespace NotSoSmartSaverAPI.Processors
{
    public class IncomeProcessor : IIncomeProcessor
    {
        private readonly IUserProcessor usp;
        NSSSContext context = new NSSSContext();

        public IncomeProcessor (IUserProcessor userProcessor)
        {
            usp = userProcessor;
        }
        
        public Task<string> AddIncome(NewIncomeDTO data) => Task.Run(() =>
                                                          {
                                                              var newIncome = new Income
                                                              {
                                                                  Incomeid = Guid.NewGuid().ToString(),
                                                                  Ownerid = data.ownerId,
                                                                  Userid = data.userId,
                                                                  Moneyrecieved = (float)data.moneyReceived,
                                                                  Incometime = DateTime.Now,
                                                                  Incomename = data.incomeName
                                                              };
                                                              context.Add(newIncome);
                                                              context.SaveChanges();
                                                              return "Income Added";
                                                          }
            );

        public async Task<List<Income>> GetAllIncomes(GetAllDTO data)
        {
            List<Income> listOfIncomes;
            if (data.numberOfDaysToShow < 0)
            {
                if (data.maxNumberOfIncomesToShow < 0)
                {
                    listOfIncomes = await Task.Run(() => context.Income.Where(a => a.Ownerid == data.ownerId)
                                                                       .ToList());
                }
                else
                    listOfIncomes = await Task.Run(() => context.Income.Where(a => a.Ownerid == data.ownerId)
                                                                       .OrderBy(a => a.Incometime)
                                                                       .Take(data.maxNumberOfIncomesToShow).ToList());
            }
            else
            {
                if (data.maxNumberOfIncomesToShow < 0)
                {
                    listOfIncomes = await Task.Run(() => context.Income.Where(a => a.Ownerid == data.ownerId && a.Incometime > DateTime.Now.AddDays(-data.numberOfDaysToShow))
                                                                       .ToList());
                }
                else
                    listOfIncomes = await Task.Run(() => context.Income.Where(a => a.Ownerid == data.ownerId && a.Incometime > DateTime.Now.AddDays(-data.numberOfDaysToShow))
                                                                       .OrderBy(a => a.Incometime)
                                                                       .Take(data.maxNumberOfIncomesToShow).ToList());
            }
            return listOfIncomes;
        }

        public async Task<List<IncomeSumByOwnerDTO>> GetSumOfIncomesByOwner(IncomesByOwnerDTO data)
        {
            GetAllDTO data2 = new GetAllDTO();
            data2.ownerId = data.ownerId;
            data2.numberOfDaysToShow = data.numberOfDaysToShow;
            data2.maxNumberOfIncomesToShow = -1;

            List<Income> listOfIncomes = await Task.Run(() => GetAllIncomes(data2));
            List<IncomeSumByOwnerDTO> modifiedIncomes = (await Task.WhenAll(listOfIncomes.
                GroupBy(e => e.Userid).
                Select(async ce => new IncomeSumByOwnerDTO
                {
                    userName = (await Task.Run(() => usp.GetUserById(new UserIdDTO { userId = ce.First().Userid }))).Username,
                    sum = ce.Sum(e => e.Moneyrecieved)
                }))).ToList();
            return modifiedIncomes;
        }

        public Task<bool> ModifyIncome(ModifyIncomeDTO data) => Task.Run(() =>
        {
            var income = context.Income.First(a => a.Incomeid == data.incomeId);
            income.Incomename = data.incomeName;
            income.Moneyrecieved = (float)data.moneyReceived;
            context.SaveChanges();
            return true;
        });

        public Task<bool> RemoveIncome(string incomeId) => Task.Run(() =>
        {
            context.Remove(context.Income.Single(a => a.Incomeid == incomeId));
            context.SaveChanges();
            return true;
        }
        );
    }
}

