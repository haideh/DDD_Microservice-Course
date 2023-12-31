using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Utility.AbstractQuery
{
    public abstract class AbstractGenericRepository<T> : IAbstractGenericRepository<T> where T : class
    {
        private DbContext context;

        protected AbstractGenericRepository(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            return context.Set<T>().Where(predicate);
        }


        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }



        public void AddRange(List<T> entitys)
        {
            foreach (T entity in entitys)
            {
                context.Set<T>().Add(entity);
            }
        }

        public void DeleteRange(List<T> entitys)
        {
            foreach (T entity in entitys)
            {
                Delete(entity);
            }
        }

        public void Update(T entity, Action<T> updateAction)
        {
            context.Entry(entity).State = EntityState.Unchanged;
            updateAction(entity);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }


        public void UpdateRage(List<T> entitys, Action<T> updateAction)
        {
            foreach (T entity in entitys)
            {
                Update(entity, updateAction);
            }
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Any(expression);
        }

        public T GetById(long id)
        {
            return context.Find<T>(id);
        }
    }
}