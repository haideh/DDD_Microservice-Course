using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utility.AbstractQuery
{
    public interface IAbstractGenericRepository<T> where T : class
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetById(long id);
        List<T> GetAll();
        void Add(T entity);
        Task AddAsync(T entity);
        void Delete(T entity);
        void AddRange(List<T> entitys);
        void DeleteRange(List<T> entitys);
        void Update(T entity, Action<T> updateAction);

        bool SaveChanges();
        //void UpdateWithNull(T entity, Action<T> updateAction, List<string> updateNullFields);
        void UpdateRage(List<T> entitys, Action<T> updateAction);

        bool Exists(Expression<Func<T, bool>> expression);

    }
}
