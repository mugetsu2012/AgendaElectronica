using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AgendaElectronica.Core;
using Microsoft.EntityFrameworkCore;

namespace AgendaElectronica.Data
{
    public class Repository<T>: IRepository<T> where T:class
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _entities;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IQueryable<T> Table => this.Entities;

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity, bool realizarSaveChanges = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);
            if (realizarSaveChanges)
            {
                _dbContext.SaveChanges();
            }
        }

        public void Delete(T entity, bool realizarSaveChanges = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);

            if (realizarSaveChanges)
            {
                _dbContext.SaveChanges();
            }
        }

        public T FindBy(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null, bool trackear = false)
        {
            IQueryable<T> query = Entities.Where(predicate);

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return trackear ? query.FirstOrDefault() : query.AsNoTracking().FirstOrDefault();
        }

        public List<T> GetList(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null, bool trackear = false)
        {
            IQueryable<T> query = Entities.Where(predicate);

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return trackear ? query.ToList() : query.AsNoTracking().ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        #region Utilidades privades

        private DbSet<T> Entities => _entities ?? (_entities = _dbContext.Set<T>());

        #endregion
    }
}
