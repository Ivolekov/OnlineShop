namespace OnlineStorePlatform.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        void InsertOrUpdate(T entity);

        void Delete(T entity);

        T FindByPredicate(Expression<Func<T, bool>> predicate);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        IQueryable<T> Take(int count);

        T GetById(int id);

        T GetByStringId(string id);

        T SingleOrDefault(Expression<Func<T, bool>> predicate);
    }
}
