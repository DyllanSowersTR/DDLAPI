using DDL.Models;
using DDL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingGroupsController : ControllerBase
    {
        private readonly VotingGroupService VotingGroupService;

        public VotingGroupsController(VotingGroupService votingGroupService)
        {
            VotingGroupService = votingGroupService;
        }

        [HttpGet]
        public ActionResult<List<VotingGroup>> Get() =>
            VotingGroupService.Get();

        [HttpGet("{id:length(24)}", Name = "GetVotingGroup")]
        public ActionResult<VotingGroup> Get(string id)
        {
            VotingGroup VotingGroup = VotingGroupService.Get(id);

            if (VotingGroup == null)
            {
                return NotFound();
            }

            return VotingGroup;
        }

        [HttpPost]
        public ActionResult<VotingGroup> Create(VotingGroup votingGroup)
        {
            VotingGroupService.Create(votingGroup);

            return CreatedAtRoute("GetVotingGroup", new { id = votingGroup.Id.ToString() }, votingGroup);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, VotingGroup votingGroupIn)
        {
            VotingGroup VotingGroup = VotingGroupService.Get(id);

            if (VotingGroup == null)
            {
                return NotFound();
            }

            VotingGroupService.Update(id, votingGroupIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            VotingGroup VotingGroup = VotingGroupService.Get(id);

            if (VotingGroup == null)
            {
                return NotFound();
            }

            VotingGroupService.Remove(VotingGroup.Id);

            return NoContent();
        }
    }
}