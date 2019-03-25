using PPT.Domain.Core;
using PPT.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace PPT.Infrastructure.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        protected UnitOfWork unitOfWork;
        protected DbContext context;
        private DbSet<TEntity> dbSet;
        private string setName;

        #endregion

        #region Properties

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public IQueryable<TEntity> DbSet
        {
            get { return this.dbSet.AsQueryable<TEntity>(); }
        }

        #endregion

        #region Constructors

        public Repository(string setName, IUnitOfWork UnitOfWork)
        {
            this.unitOfWork = (UnitOfWork)UnitOfWork;
            this.context = this.unitOfWork;
            this.dbSet = this.unitOfWork.Set<TEntity>();
            this.setName = setName;
        }

        #endregion

        #region Methods

        public virtual IEnumerable<TEntity> GetAll(IList<string> includes = null)
        {
            IQueryable<TEntity> query = dbSet.AsQueryable().AsNoTracking();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.AsEnumerable<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter, IList<string> includes = null)
        {
            if (filter == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("filter not set");

            IQueryable<TEntity> query = dbSet.AsQueryable().AsNoTracking();

            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.Where(filter).AsEnumerable<TEntity>();
        }

        public void Save(TEntity item)
        {
            if (item.Id == default(System.Guid) || string.IsNullOrEmpty(item.Id.ToString()))
                item.Id = Guid.NewGuid();

            dbSet.Add(item);
            context.SaveChanges();
        }

        public void Dispose()
        {
        }
        #endregion           
    }



}
