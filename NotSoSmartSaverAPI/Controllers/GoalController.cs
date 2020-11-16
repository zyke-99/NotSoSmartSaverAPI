using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotSoSmartSaverAPI.DTO.GoalDTO;
using NotSoSmartSaverAPI.Interfaces;

namespace NotSoSmartSaverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {

        IGoalProcessor _goalProcessor;

        public GoalController(IGoalProcessor goalProcessor)
        {
            _goalProcessor = goalProcessor;
        }


        [HttpGet]
        public IActionResult GetGoals([FromBody]GetGoalsDTO data)
        {
            return Ok(_goalProcessor.getGoals(data));
        }


        [HttpDelete("{goalID}")]
        public IActionResult RemoveGoal(string goalID)
        {
            _goalProcessor.removeGoal(goalID);
            return Ok("Goal removed");
        }


        [HttpPut]
        public IActionResult ModifyGoal([FromBody]ModifyGoalDTO data)
        {
            _goalProcessor.modifyGoal(data);
            return Ok("Goal modified");
        }

        [HttpPost]
        public IActionResult AddNewGoal([FromBody] NewGoalDTO data)
        {
            _goalProcessor.addNewGoal(data);
            return Ok("Goal added");
        }

        [HttpDelete("CompleteGoal/{goalID}")]
        public IActionResult CompleteGoal(string goalID)
        {
            if (_goalProcessor.CompleteGoal(goalID))
            {
                return Ok("Goal complete");
            }
            else return BadRequest("Goal not complete");
        }


        [HttpPut("AddMoneyToGoal")]
        public IActionResult AddMoneyToGoal(AddMoneyDTO data)
        {
            _goalProcessor.addMoneyToGoal(data);
            return Ok("Money added");
        }

    }
}
