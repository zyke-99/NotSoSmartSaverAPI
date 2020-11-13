using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotSoSmartSaverAPI.DTO.GroupsDTO;
using NotSoSmartSaverWFA.DataAccess;
using NotSoSmartSaverWFA.Models;

namespace NotSoSmartSaverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {


        IGroupProcessor grp;
        IUserProcessor usp;
        IBudgetProcessor bup;

        public GroupController(IGroupProcessor groupProcessor, IUserProcessor userProcessor, IBudgetProcessor budgetProcessor)
        {
            grp = groupProcessor;
            usp = userProcessor;
            bup = budgetProcessor;
        }

        [HttpPut("AddUserToGroup")]
        public IActionResult AddUserToGroup([FromBody] AddUserToGroupDTO data)
        {
            foreach (var u in grp.getUsersOfGroup(data.groupId))
            {
                if (u.userEmail == data.userEmail)
                {
                    return BadRequest("User already in this group");
                }
            }
            if (usp.getUserByUserEmail(data.userEmail) != null)
            {
                grp.addUserToGroup(data.groupId, usp.getUserByUserEmail(data.userEmail).userId);
                return Ok("User added to group");
            }

            return BadRequest("No such user exists");

        }

        //public void createGroup(User user, Group group)
        //{
        //    grp.createNewGroup(user.userId, group.groupName);
        //    bup.createNewBudget(group.groupId);
        //}

        [HttpGet("GetGroups")]
        public IActionResult GetGroups(User user)
        {
            return Ok(grp.getUserGroups(user.userId));
        }

        [HttpGet("GetGroupUsers")]
        public IActionResult GetGroupUsers([FromBody] GroupIdDTO data)
        {
            return Ok(grp.getUsersOfGroup(data.groupId));
        }

        [HttpDelete("RemoveGroup")]
        public IActionResult RemoveGroup([FromBody] GroupIdDTO data)
        {
            grp.removeGroup(data.groupId);
            return Ok("Group removed");
        }


        [HttpDelete("RemoveUserFromGroup")]
        public IActionResult RemoveUserFromGroup([FromBody] RemoveUserFromGroupDTO data)
        {
            grp.removeUserFromGroup(data.groupId, data.userId);
            if (grp.getUsersOfGroup(data.groupId).Count == 0)
            {
                grp.removeGroup(data.groupId);
            }
            return Ok("User removed from group");
        }



    }
}
