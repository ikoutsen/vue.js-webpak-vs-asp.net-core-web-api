using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagetWebAPI.DAL;

namespace TaskManagetWebAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller {
        private IUnitOfWork data;
        public TasksController(IUnitOfWork data) {
            this.data = data;
        }
        [HttpGet]
        public async Task<ActionResult> Get() {
            var tasks = await data.Tasks.GetAll(
                includeProperties: "TaskState, CreatorUser, WorkerUser");
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) {
            var tasks = await data.Tasks.GetById(id);
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Model.Task tasks) {
            await data.Tasks.Add(tasks);
            await data.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put(Model.Task tasks) {
            await data.Tasks.Update(tasks);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Model.Task tasks) {
            await data.Tasks.Delete(tasks);
            return Ok();
        }
    }
}
