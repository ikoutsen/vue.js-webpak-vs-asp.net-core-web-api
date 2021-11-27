using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskManagetWebAPI.DAL {
    public class EFRepository<T> : IRepository<T> where T : Model.ModelEntity {
        protected Model.TaskContext context;
        public EFRepository(Model.TaskContext context) {
            this.context = context;
        }
        public async Task<IEnumerable<T>> GetAll(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "") {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();
        }
        public async Task<T> GetById(int id) {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task Add(T entity) {
            await context.Set<T>().AddAsync(entity);
        }
        public async Task Update(T entity) {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task Delete(T entity) {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
