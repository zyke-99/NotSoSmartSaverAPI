using System;
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
            if (VeryTemporary.getMoney(usp.getUserById(new UserIdDTO { userId = data.userId}), data.ownerId) >= data.moneyUsed)// && user.userMoney >= expense.moneyUsed)
            {
                exp.AddExpense(data);
                return Ok("Expense added");
            }

            return BadRequest("Expense not added");
        }

        [HttpGet("GetExpenses")]
        public IActionResult GetExpenses([FromBody] GetExpensesDTO data)
        {
            //List<Expense> expensesTemp = exp.getExpenses(data.ownerId).OrderByDescending(x => x.expenseTime).ToList();
            //List<Expense> expenses = new List<Expense>();
            //if (expensesTemp == null) return Ok(new List<Expense>());
            //if (data.maxNumberOfExpensesToShow <= -1)
            //{
            //    if (data.numberOfDaysToShow <= -1)
            //    {
            //        return Ok(expensesTemp);
            //    }
            //    else
            //    {
            //        List<Expense> modifiedExpenses =
            //            (from expense in expensesTemp
            //             where expense.expenseTime > DateTime.Now.AddDays(-data.numberOfDaysToShow)
            //             select expense).ToList();
            //        return Ok(modifiedExpenses);
            //    }
            //}
            //else
            //{
            //    if (data.numberOfDaysToShow <= -1)
            //    {
            //        return Ok(expensesTemp.Take(data.maxNumberOfExpensesToShow).ToList());
            //    }
            //    else
            //    {
            //        List<Expense> modifiedExpenses =
            //            (from expense in expensesTemp
            //             where expense.expenseTime > DateTime.Now.AddDays(-data.numberOfDaysToShow)
            //             select expense).ToList();
            //        return Ok(modifiedExpenses.Take(data.maxNumberOfExpensesToShow).ToList());
            //    }
            //}
            return Ok(exp.GetExpenses(data));
        }


        [HttpGet("GetSumOfExpensesByCategory")]
        public IActionResult GetSumOfExpensesByCategory([FromBody] ExpensesByOwnerDTO data)
        {
            //List<SumByCatDTO> catSums = new List<SumByCatDTO>();
            //List<Expense> expenses = exp.getExpenses(data.ownerId);
            //foreach (CategoryEnum e in Enum.GetValues(typeof(CategoryEnum)))
            //{
            //    double sum = 0;
            //    foreach (var expense in expenses)
            //    {
            //        if (expense.expenseCategory == e && expense.expenseTime >= DateTime.Now.AddDays(-data.numberOfDaysToShow))
            //        {
            //            sum += expense.moneyUsed;
            //        }
            //        else if (expense.expenseCategory == e && data.numberOfDaysToShow == -1)
            //        {
            //            sum += expense.moneyUsed;
            //        }
            //    }
            //    var tuple = new SumByCatDTO();
            //    tuple.category = Enum.GetName(typeof(CategoryEnum), e);
            //    tuple.sum = sum;
            //    catSums.Add(tuple);
            //}
            return Ok(exp.GetSumOfExpensesByCategory(data));
        }

        [HttpGet("GetSumOfExpensesByOwner")]
        public IActionResult GetSumOfExpensesByOwner([FromBody] ExpensesByOwnerDTO data)
        {
            //List<Expense> expenses = new List<Expense>();
            //expenses = exp.getExpenses(data.ownerId);
            //if (data.numberOfDaysToShow >= 0)
            //{
            //    expenses = (
            //        from expense in expenses
            //        where expense.expenseTime >= DateTime.Now.AddDays(-data.numberOfDaysToShow)
            //        select expense).ToList();
            //}
            //List<SumByOwnerDTO> modifiedExpenses = expenses
            //    .GroupBy(e => e.userId)
            //    .Select(ce => new SumByOwnerDTO
            //    {
            //        userName = usp.getUserById(ce.First().userId).userName,
            //        sum = ce.Sum(e => e.moneyUsed),
            //    }
            //    ).ToList();

            return Ok(exp.GetSumOfExpensesByOwner(data));
        }



    }
}
