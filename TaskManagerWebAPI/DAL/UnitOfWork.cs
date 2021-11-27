using System;

namespace TaskManagetWebAPI.DAL {
    public class UnitOfWork : IUnitOfWork, IDisposable {
        private Model.TaskContext context;

        private IRepository<Model.Task> ticketsRepository;
        private IRepository<Model.TaskState> ticketStatusesRepository;
        private IRepository<Model.User> usersRepository;

        public UnitOfWork(Model.TaskContext context) {
            this.context = context;
        }
        public IRepository<Model.Task> Tasks {
            get {
                return ticketsRepository ?? new EFRepository<Model.Task>(context);
            }
        }
        public IRepository<Model.TaskState> TaskStates {
            get {
                return ticketStatusesRepository ?? new EFRepository<Model.TaskState>(context);
            }
        }
        public IRepository<Model.User> Users {
            get {
                return usersRepository ?? new EFRepository<Model.User>(context);
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing) {
            if (!disposed && disposing)
                context.Dispose();
            disposed = true;
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async System.Threading.Tasks.Task SaveAsync() {
            await context.SaveChangesAsync();
        }
    }
}