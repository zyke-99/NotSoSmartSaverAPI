using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotSoSmartSaverAPI.DTO.BudgetDTO;
using NotSoSmartSaverWFA;
using NotSoSmartSaverWFA.DataAccess;
using NotSoSmartSaverWFA.Models;

namespace NotSoSmartSaverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetProcessor _budgetProcessor;

        public BudgetController(IBudgetProcessor budgetProcessor)
        {
            _budgetProcessor = budgetProcessor;
        }


        [HttpGet("GetValuesOfCategoryLimits")]
        public IActionResult GetValuesOfCategoryLimits([FromBody] GetBudgetDTO data)
        {

            Budget budget = _budgetProcessor.getBudget(data.ownerId);
            List<string> limits = new List<string>
            {
                budget.Food.ToString(),
                budget.Clothes.ToString(),
                budget.Leisure.ToString(),
                budget.Rent.ToString(),
                budget.Loan.ToString(),
                budget.Alcohol.ToString(),
                budget.Tobacco.ToString(),
                budget.Insurance.ToString(),
                budget.Car.ToString(),
                budget.Subscriptions.ToString(),
                budget.Goal.ToString(),
                budget.Other.ToString()
            };
            return Ok(limits);
        }

        [HttpPut("ModifyBudget")]
        public void modifyBudget([FromBody] ModifyBudgetDTO data)
        {
            List<double> values = data.listOfValues.ToDoubleListWithoutNegatives();

            _budgetProcessor.modifyBudget(data.ownerId, values);
        }
    }
}
