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
        public async Task<IActionResult> GetGoals(string ownerId)
        {
            GetGoalsDTO data = new GetGoalsDTO { ownerId = ownerId };
            return Ok(Task.Run(() => _goalProcessor.getGoals(data)));
        }


        [HttpDelete("{goalID}")]
        public async Task<IActionResult> RemoveGoal(string goalID)
        {
            await Task.Run(() => _goalProcessor.removeGoal(goalID));
            return Ok("Goal removed");
        }


        [HttpPut]
        public async Task<IActionResult> ModifyGoal([FromBody]ModifyGoalDTO data)
        {
            await Task.Run(() => _goalProcessor.modifyGoal(data));
            return Ok("Goal modified");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGoal([FromBody] NewGoalDTO data)
        {
            await Task.Run(() => _goalProcessor.addNewGoal(data));
            return Ok("Goal added");
        }

        [HttpDelete("CompleteGoal/{goalID}")]
        public async Task<IActionResult> CompleteGoal(string goalID)
        {
            if (await Task.Run(() => _goalProcessor.CompleteGoal(goalID)))
            {
                return Ok("Goal complete");
            }
            else return BadRequest("Goal not complete");
        }


        [HttpPut("AddMoneyToGoal")]
        public async Task<IActionResult> AddMoneyToGoal([FromBody]AddMoneyDTO data)
        {
            await Task.Run(() => _goalProcessor.addMoneyToGoal(data));
            return Ok("Money added");
        }

    }
}
