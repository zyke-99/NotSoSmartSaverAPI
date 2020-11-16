using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotSoSmartSaverAPI.DTO.GroupsDTO;
using NotSoSmartSaverWFA.DataAccess;
using NotSoSmartSaverAPI.ModelsGenerated;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.Processors;

namespace NotSoSmartSaverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {


        private readonly IGroupProcessor grp;
        private readonly IUserProcessor usp;
        private readonly IBudgetProcessor bup;

        public GroupController(IGroupProcessor groupProcessor, IUserProcessor userProcessor, IBudgetProcessor budgetProcessor)
        {
            grp = groupProcessor;
            usp = userProcessor;
            bup = budgetProcessor;
        }

        [HttpPut("AddUserToGroup")]
        public IActionResult AddUserToGroup([FromBody] AddUserToGroupDTO data)
        {
            foreach (var u in grp.GetGroupUsers(new GroupIdDTO { groupId = data.groupId }))
            {
                if (u.Useremail == data.userEmail)
                {
                    return BadRequest("User already in this group");
                }
            }
            if (usp.getUserByUserEmail(data.userEmail) != null)
            {
                grp.AddUserToGroup(data);
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
        public IActionResult GetGroups(Users user)
        {
            return Ok(grp.GetGroups( new GetUserGroupsDTO { userId = user.Userid }));
        }

        [HttpGet("GetGroupUsers")]
        public IActionResult GetGroupUsers([FromBody] GroupIdDTO data)
        {
            return Ok(grp.GetGroupUsers(data));
        }

        [HttpDelete("RemoveGroup")]
        public IActionResult RemoveGroup([FromBody] GroupIdDTO data)
        {
            grp.RemoveGroup(data);
            return Ok("Group removed");
        }


        [HttpDelete("RemoveUserFromGroup")]
        public IActionResult RemoveUserFromGroup([FromBody] RemoveUserFromGroupDTO data)
        {
            grp.RemoveUserFromGroup(data);
            if (grp.GetGroupUsers(new GroupIdDTO { groupId = data.groupId}).Count == 0)
            {
                grp.RemoveGroup(new GroupIdDTO { groupId = data.groupId});
            }
            return Ok("User removed from group");
        }



    }
}
