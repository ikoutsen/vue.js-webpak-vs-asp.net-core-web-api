using System.Threading.Tasks;

namespace TaskManagetWebAPI.DAL {
    public interface IUnitOfWork {
        public IRepository<Model.Task> Tasks { get;  }
        public IRepository<Model.TaskState> TaskStates{ get;  }
        public IRepository<Model.User> Users{ get;  }
        public Task SaveAsync();
    }
}
