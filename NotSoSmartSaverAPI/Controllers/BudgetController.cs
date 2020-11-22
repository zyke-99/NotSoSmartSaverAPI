using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotSoSmartSaverAPI.DTO.BudgetDTO;
using NotSoSmartSaverWFA;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.Processors;
using NotSoSmartSaverAPI.ModelsGenerated;

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
        public IActionResult GetValuesOfCategoryLimits(string ownerId)
        {
            GetBudgetDTO data = new GetBudgetDTO {ownerId = ownerId};
            List<SingleBudgetDTO> limits = _budgetProcessor.getBudget(data);
            return Ok(limits);
        }

        [HttpPut("ModifyBudget")]
        public void modifyBudget([FromBody] ModifyBudgetDTO data)
        {
            _budgetProcessor.modifyBudget(data);
        }
    }
}
