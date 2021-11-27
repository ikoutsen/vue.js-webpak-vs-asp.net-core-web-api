using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagetWebAPI.DAL;

namespace TaskManagetWebAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller {
        private IUnitOfWork data;
        public UsersController(IUnitOfWork data) {
            this.data = data;
        }
        [HttpGet]
        public async Task<ActionResult> Get() {
            var users = await data.Users.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) {
            var user = await data.Users.GetById(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Model.User user) {
            await data.Users.Add(user);
            await data.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put(Model.User user) {
            await data.Users.Update(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Model.User user) {
            await data.Users.Delete(user);
            return Ok();
        }
    }
}
