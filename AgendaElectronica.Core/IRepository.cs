using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AgendaElectronica.Core
{
    public interface IRepository<T>: IDisposable where T: class
    {
        T GetById(object id);

        void Insert(T entity, bool realizarSaveChanges = true);

        void Delete(T entity, bool realizarSaveChanges = true);

        IQueryable<T> Table { get; }

        T FindBy(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null, bool trackear = false);

        List<T> GetList(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null, bool trackear = false);

        void SaveChanges();

    }
}
