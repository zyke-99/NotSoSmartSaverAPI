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
        public async Task<IActionResult> AddUserToGroup([FromBody] AddUserToGroupDTO data)
        {
            foreach (var u in await grp.GetGroupUsers(new GroupIdDTO { groupId = data.groupId }))
            {
                if (u.Useremail == data.userEmail)
                {
                    return BadRequest("User already in this group");
                }
            }
            if (usp.GetUserByUserEmail(data.userEmail) != null)
            {
                await Task.Run(() => grp.AddUserToGroup(data));
                return Ok("User added to group");
            }

            return BadRequest("No such user exists");

        }

        [HttpPost]
        public async Task<IActionResult> createGroup(NewGroupDTO data)
        {

            if (await Task.Run(() => grp.CreateGroup(data))) return Ok("Group created");
            else return BadRequest("Group not created");

        }

        [HttpGet("GetGroups")]
        public async Task<IActionResult> GetGroups(string userId)
        {
            return Ok(Task.Run(() => grp.GetGroups( new GetUserGroupsDTO { userId = userId })));
        }

        [HttpGet("GetGroupUsers")]
        public async Task<IActionResult> GetGroupUsers(string groupId)
        {
            GroupIdDTO data = new GroupIdDTO { groupId = groupId };
            return Ok(Task.Run(() => grp.GetGroupUsers(data)));
        }

        [HttpDelete("RemoveGroup/{groupId}")]
        public async Task<IActionResult> RemoveGroup(string groupId)
        {
            GroupIdDTO data = new GroupIdDTO { groupId = groupId };
            await Task.Run(() => grp.RemoveGroup(data));
            return Ok("Group removed");
        }


        [HttpDelete("RemoveUserFromGroup/{userId}&{groupId}")]
        public async Task<IActionResult> RemoveUserFromGroup(string userId, string groupId)
        {
            RemoveUserFromGroupDTO data = new RemoveUserFromGroupDTO { userId = userId, groupId = groupId };
            await Task.Run(() => grp.RemoveUserFromGroup(data));
            if ((await grp.GetGroupUsers(new GroupIdDTO { groupId = data.groupId})).Count == 0)
            {
                await grp.RemoveGroup(new GroupIdDTO { groupId = data.groupId });
            }
            return Ok("User removed from group");
        }


        [HttpPut("ModifyGroup")]

        public async Task<IActionResult> ModifyGroup([FromBody] ModifyGroupDTO data)
        {
            await Task.Run(() => grp.ModifyGroup(data));
            return Ok("Group modified");
        }


    }
}
