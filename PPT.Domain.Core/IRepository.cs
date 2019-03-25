using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;

namespace PPT.Domain.Core
{
    public interface IRepository<TEntity>:IDisposable
    {
        #region Properties

        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntity> DbSet { get; }

        #endregion Properties

        #region Methods

        void Save(TEntity item);

        IEnumerable<TEntity> GetAll(IList<string> includes = null);

        IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter, IList<string> includes = null);



        #endregion
    }
}
