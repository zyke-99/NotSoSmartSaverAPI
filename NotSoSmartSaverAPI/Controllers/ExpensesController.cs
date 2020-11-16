﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotSoSmartSaverAPI.DTO.ExpensesDTO;
using NotSoSmartSaverAPI.ModelsGenerated;
using NotSoSmartSaverWFA;
//using NotSoSmartSaverWFA.DataAccess;
//using NotSoSmartSaverWFA.DataAccess.DataValidation;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.DataVerification;
using NotSoSmartSaverAPI.Processors;
using NotSoSmartSaverAPI.DTO.UserDTO;
//using System.Web.Http;

namespace NotSoSmartSaverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {


        private readonly IExpensesProcessor exp;
        private readonly IUserProcessor usp;
        private readonly IDataValidation dv;


        public ExpensesController(IExpensesProcessor expensesProcessor, IUserProcessor userProcessor, IDataValidation dataValidation)
        {
            exp = expensesProcessor;
            usp = userProcessor;
            dv = dataValidation;
        }


        [HttpPost]
        public IActionResult AddExpense([FromBody] NewExpenseDTO data)
        {
            if (dv.isExpenseValid(data))
            {
                exp.AddExpense(data);
                return Ok("Expense added");
            }

            return BadRequest("Expense not added");
        }

        [HttpGet("GetExpenses")]
        public IActionResult GetExpenses([FromBody] GetExpensesDTO data)
        {
            return Ok(exp.GetExpenses(data));
        }


        [HttpGet("GetSumOfExpensesByCategory")]
        public IActionResult GetSumOfExpensesByCategory([FromBody] ExpensesByOwnerDTO data)
        {
            return Ok(exp.GetSumOfExpensesByCategory(data));
        }

        [HttpGet("GetSumOfExpensesByOwner")]
        public IActionResult GetSumOfExpensesByOwner([FromBody] ExpensesByOwnerDTO data)
        {
            return Ok(exp.GetSumOfExpensesByOwner(data));
        }

        [HttpDelete("{expenseID}")]
        public IActionResult RemoveExpense (string expenseID)
        {
            exp.RemoveExpense(expenseID);
            return Ok("Expense removed");
        }

        [HttpPut("ModifyExpense")]
        public IActionResult ModifyExpense ([FromBody] NewExpenseDTO data)
        {
            return Ok(exp.ModifyExpense(data));
        }

    }
}
