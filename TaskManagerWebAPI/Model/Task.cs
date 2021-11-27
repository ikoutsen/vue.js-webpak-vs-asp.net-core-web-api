using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagetWebAPI.Model {
    public class Task : ModelEntity {
        public string Description { get; set; }
        public int TaskStateId { get; set; }
        public TaskState TaskState { get; set; }
        public DateTime CreatingDate { get; set; }
        public int CreatorUserId { get; set; }
        public User CreatorUser { get; set; }
        public int? WorkerUserId { get; set; }
        public User WorkerUser { get; set; }
    }
}