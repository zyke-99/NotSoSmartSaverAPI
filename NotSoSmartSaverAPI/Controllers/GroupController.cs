using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotSoSmartSaverAPI.DTO.GroupsDTO;
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
            if (usp.GetUserByUserEmail(data.userEmail) != null)
            {
                grp.AddUserToGroup(data);
                return Ok("User added to group");
            }

            return BadRequest("No such user exists");

        }

        [HttpPost]
        public IActionResult createGroup(NewGroupDTO data)
        {

            if (grp.CreateGroup(data)) return Ok("Group created");
            else return BadRequest("Group not created");

        }

        [HttpGet("GetGroups/{userId}")]
        public IActionResult GetGroups(string userId)
        {
            return Ok(grp.GetGroups( new GetUserGroupsDTO { userId = userId }));
        }

        [HttpGet("GetGroupUsers/{groupId}")]
        public IActionResult GetGroupUsers(string groupId)
        {
            GroupIdDTO data = new GroupIdDTO { groupId = groupId };
            return Ok(grp.GetGroupUsers(data));
        }

        [HttpDelete("RemoveGroup/{groupId}")]
        public IActionResult RemoveGroup(string groupId)
        {
            GroupIdDTO data = new GroupIdDTO { groupId = groupId };
            grp.RemoveGroup(data);
            return Ok("Group removed");
        }


        [HttpDelete("RemoveUserFromGroup/{userId}&{groupId}")]
        public IActionResult RemoveUserFromGroup(string userId, string groupId)
        {
            RemoveUserFromGroupDTO data = new RemoveUserFromGroupDTO { userId = userId, groupId = groupId };
            grp.RemoveUserFromGroup(data);
            if (grp.GetGroupUsers(new GroupIdDTO { groupId = data.groupId}).Count == 0)
            {
                grp.RemoveGroup(new GroupIdDTO { groupId = data.groupId});
            }
            return Ok("User removed from group");
        }


        [HttpPut("ModifyGroup")]

        public IActionResult ModifyGroup([FromBody] ModifyGroupDTO data)
        {
            grp.ModifyGroup(data);
            return Ok("Group modified");
        }


    }
}
