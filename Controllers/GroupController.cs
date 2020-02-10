using DDL.Models;
using DDL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/* For handling CRUD operations for Group
 * Supports GET, POST, PUT, and DELETE HTTP requests
 */
namespace DDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _GroupService;

        public GroupController(GroupService GroupService)
        {
            _GroupService = GroupService;
        }

        [HttpGet]
        public ActionResult<List<Group>> Get() =>
            _GroupService.Get();

        [HttpGet("{id:length(24)}", Name = "GetGroup")]
        public ActionResult<Group> Get(string id)
        {
            var Group = _GroupService.Get(id);

            if (Group == null)
            {
                return NotFound();
            }

            return Group;
        }

        [HttpPost]
        public ActionResult<Group> Create(Group Group)
        {
            _GroupService.Create(Group);

            return CreatedAtRoute("GetGroup", new { id = Group.Id.ToString() }, Group);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Group GroupIn)
        {
            var Group = _GroupService.Get(id);

            if (Group == null)
            {
                return NotFound();
            }

            _GroupService.Update(id, GroupIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Group = _GroupService.Get(id);

            if (Group == null)
            {
                return NotFound();
            }

            _GroupService.Remove(Group.Id);

            return NoContent();
        }
    }
}