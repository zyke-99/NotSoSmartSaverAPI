using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotSoSmartSaverAPI.DTO.IncomeDTO;
//using NotSoSmartSaverWFA.DataAccess;
//using NotSoSmartSaverWFA.DataAccess.DataValidation;
using NotSoSmartSaverAPI.Processors;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.ModelsGenerated;
using System.Net;

namespace NotSoSmartSaverAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]


    public class IncomeController : ControllerBase
    {
        private readonly IIncomeProcessor inp;
        private readonly IUserProcessor usp;
        private readonly IDataValidation dv;

        public IncomeController(IIncomeProcessor incomeProcessor, IUserProcessor userProcessor, IDataValidation dataValidation)
        {
            inp = incomeProcessor;
            usp = userProcessor;
            dv = dataValidation;
        }



        [HttpGet("GetAllIncomes")]
        public async Task<IActionResult> GetAllIncomes(string ownerId, int numberOfDaysToShow, int maxNumberOfIncomesToShow)
        {
            GetAllDTO data = new GetAllDTO { ownerId = ownerId, numberOfDaysToShow = numberOfDaysToShow, maxNumberOfIncomesToShow = maxNumberOfIncomesToShow };
            return Ok(await Task.Run(() => inp.GetAllIncomes(data)));
        }


        [HttpGet("GetSumOfIncomesByOwner")]
        public async Task<IActionResult> GetSumOfIncomesByOwner(string ownerId, int numberOfDaysToShow)
        {
            IncomesByOwnerDTO data = new IncomesByOwnerDTO { ownerId = ownerId, numberOfDaysToShow = numberOfDaysToShow };
            return Ok(await Task.Run(() => inp.GetSumOfIncomesByOwner(data)));
        }


        [HttpPost]
        public async Task<IActionResult> AddIncome([FromBody] NewIncomeDTO data)
        {
            try
            {
                await Task.Run(() => inp.AddIncome(data));

            }
            catch (WebException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

            }
            return Ok("Income added");
        }


        [HttpDelete("{incomeID}")]
        
        public async Task<IActionResult> RemoveIncome(string incomeID)
        {
            await Task.Run(() => inp.RemoveIncome(incomeID));
            return Ok("Income removed");
        }

        [HttpPut]
        public async Task<IActionResult> ModifyIncome([FromBody]NewIncomeDTO data)
        {
            await Task.Run(() => inp.ModifyIncome(data));
            return Ok("Income modified");
        }

    }
}
