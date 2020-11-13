using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotSoSmartSaverAPI.DTO.IncomeDTO;
using NotSoSmartSaverWFA.DataAccess;
using NotSoSmartSaverWFA.DataAccess.DataValidation;
using NotSoSmartSaverWFA.Models;

namespace NotSoSmartSaverAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

   
    public class IncomeController : ControllerBase
    {
        IIncomeProcessor inp;
        IUserProcessor usp;
        IDataValidation dv;


        public IncomeController(IIncomeProcessor incomeProcessor, IUserProcessor userProcessor, IDataValidation dataValidation)
        {
            inp = incomeProcessor;
            usp = userProcessor;
            dv = dataValidation;
        }


        [HttpGet("GetAllIncomes")]
        public IActionResult GetAllIncomes ([FromBody]GetAllDTO data)
        {
            List<Income> incomesTemp = inp.getIncomes(data.ownerId).OrderByDescending(x => x.incomeTime).ToList();
            List<Income> incomes = new List<Income>();
            if (incomesTemp == null) return Ok(new List<Income>());
            if (data.maxNumberOfIncomesToShow <= -1)
            {
                if (data.numberOfDaysToShow <= -1)
                {
                    return Ok(JsonConvert.SerializeObject(incomesTemp));
                }
                else
                {
                    List<Income> modifiedIncomes =
                        (from income in incomesTemp
                         where income.incomeTime > DateTime.Now.AddDays(-data.numberOfDaysToShow)
                         select income).ToList();
                    return Ok(modifiedIncomes);
                }
            }
            else
            {
                if (data.numberOfDaysToShow <= -1)
                {
                    return Ok(incomesTemp.Take(data.maxNumberOfIncomesToShow).ToList());
                }
                else
                {
                    List<Income> modifiedIncomes =
                        (from income in incomesTemp
                         where income.incomeTime > DateTime.Now.AddDays(-data.numberOfDaysToShow)
                         select income).ToList();
                    return Ok(modifiedIncomes.Take(data.maxNumberOfIncomesToShow).ToList());
                }
            }
        }


        [HttpGet("GetSumOfIncomesByOwner")]
        public IActionResult GetSumOfIncomesByOwner([FromBody] IncomesByOwnerDTO data)
        {
            List<Income> incomes = new List<Income>();
            incomes = inp.getIncomes(data.ownerId);
            List<SumByOwnerTuple> modifiedIncomes = incomes.
                GroupBy(e => e.userId).
                Select(ce => new SumByOwnerTuple
                {
                    userName = usp.getUserById(ce.First().userId).userName,
                    sum = ce.Sum(e => e.moneyReceived)
                }).ToList();

            return Ok(modifiedIncomes);
        }





        [HttpPost]
        public IActionResult AddIncome([FromBody] NewIncomeDTO data)
        {
            
             inp.newIncome(data.ownerId, data.userId, data.incomeName, data.moneyReceived);                
             return Ok("Income added");

        }




    }
}
