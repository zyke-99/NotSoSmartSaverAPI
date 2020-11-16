﻿using System;
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
        public IActionResult GetAllIncomes([FromBody] GetAllDTO data)
        {
            return Ok(inp.GetAllIncomes(data));
        }


        [HttpGet("GetSumOfIncomesByOwner")]
        public IActionResult GetSumOfIncomesByOwner([FromBody] IncomesByOwnerDTO data)
        {
            return Ok(inp.GetSumOfIncomesByOwner(data));
        }


        [HttpPost]
        public IActionResult AddIncome([FromBody] NewIncomeDTO data)
        {
            inp.AddIncome(data);
            return Ok("Income added");
        }


        [HttpDelete("{incomeID}")]
        
        public IActionResult RemoveIncome(string incomeID)
        {
            inp.RemoveIncome(incomeID);
            return Ok("Income removed");
        }

        [HttpPut]

        public IActionResult ModifyIncome(NewIncomeDTO data)
        {
            inp.ModifyIncome(data);
            return Ok("Income modified");
        }

    }
}
