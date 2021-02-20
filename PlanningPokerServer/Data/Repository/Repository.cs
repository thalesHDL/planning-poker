using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlanningPokerServer.Data.Context;

namespace PlanningPokerServer.Data.Repository {
    public interface IRepository<T, ID>  where T : class {
        T SelectById(ID id);
        IEnumerable<T> SelectAll();
        IEnumerable<T> SelectWhere(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteById(ID id);
    }

    public class Repository<T, ID> : IRepository<T, ID> where T : class {
        protected readonly ApplicationDatabaseContext _context;
        public Repository(ApplicationDatabaseContext context) {_context = context;}

        public T SelectById(ID id) {
            return _context.Set<T>().Find(id);
        }
        public IEnumerable<T> SelectAll() {
            return _context.Set<T>();
        }
        public IEnumerable<T> SelectWhere(Expression<Func<T, bool>> expression) {
            return _context.Set<T>().Where(expression);
        }
        public T Create(T entity) {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public T Update(T entity) {
            _context.Set<T>().Update(entity);
            return entity;
        }
        public void Delete(T entity) {
            _context.Set<T>().Remove(entity);
        }
        public void DeleteById(ID id) {
            T entity = this.SelectById(id);
            _context.Set<T>().Remove(entity);
        }
    }
}