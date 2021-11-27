using System.Collections.Generic;

namespace TaskManagetWebAPI.Model {
    public class TaskState : ModelEntity {
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
