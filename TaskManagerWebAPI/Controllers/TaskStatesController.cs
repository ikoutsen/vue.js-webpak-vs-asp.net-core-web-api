using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagetWebAPI.DAL;

namespace TaskManagetWebAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TaskStatesController : Controller {
        private IUnitOfWork data;
        public TaskStatesController(IUnitOfWork data) {
            this.data = data;
        }
        [HttpGet]
        public async Task<ActionResult> Get() {
            var taskStates = await data.TaskStates.GetAll();
            return Ok(taskStates);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) {
            var taskState = await data.TaskStates.GetById(id);
            return Ok(taskState);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Model.TaskState taskState) {
            await data.TaskStates.Add(taskState);
            await data.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put(Model.TaskState taskState) {
            await data.TaskStates.Update(taskState);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Model.TaskState taskState) {
            await data.TaskStates.Delete(taskState);
            return Ok();
        }
    }
}
