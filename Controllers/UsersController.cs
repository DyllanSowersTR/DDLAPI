using DDL.Models;
using DDL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService UserService;

        public UsersController(UserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            UserService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var User = UserService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost]
        public ActionResult<User> Create(User User)
        {
            UserService.Create(User);

            return CreatedAtRoute("GetUser", new { id = User.Id.ToString() }, User);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User UserIn)
        {
            var User = UserService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            UserService.Update(id, UserIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var User = UserService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            UserService.Remove(User.Id);

            return NoContent();
        }
    }
}