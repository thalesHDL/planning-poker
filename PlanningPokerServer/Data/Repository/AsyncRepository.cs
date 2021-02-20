using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PlanningPokerServer.Data.Context;

namespace PlanningPokerServer.Data.Repository {
    public interface IAsyncRepository<T, ID>  where T : class {
        Task<T> SelectById(ID id);
        IEnumerable<T> SelectAll();
        IEnumerable<T> SelectWhere(Expression<Func<T, bool>> expression);
        Task<T> Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        Task DeleteById(ID id);
    }

    public class AsyncRepository<T, ID> : IAsyncRepository<T, ID> where T : class {
        protected readonly ApplicationDatabaseContext _context;
        public AsyncRepository(ApplicationDatabaseContext context) {_context = context;}

        public async Task<T> SelectById(ID id) {
            return await _context.Set<T>().FindAsync(id);
        }
        public IEnumerable<T> SelectAll() {
            return _context.Set<T>();
        }
        public IEnumerable<T> SelectWhere(Expression<Func<T, bool>> expression) {
            return _context.Set<T>().Where(expression);
        }
        public async Task<T> Create(T entity) {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public T Update(T entity) {
            _context.Set<T>().Update(entity);
            return entity;
        }
        public void Delete(T entity) {
            _context.Set<T>().Remove(entity);
        }
        public async Task DeleteById(ID id) {
            T entity = await this.SelectById(id);
            _context.Set<T>().Remove(entity);
        }
    }
}