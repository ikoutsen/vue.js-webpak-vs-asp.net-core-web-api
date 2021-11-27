using System.Collections.Generic;

namespace TaskManagetWebAPI.Model {
    public class User : ModelEntity {
        public string Name { get; set; }
        public ICollection<Task> CreatorTasks { get; set; }
        public ICollection<Task> WorkerTasks { get; set; }
    }
}
