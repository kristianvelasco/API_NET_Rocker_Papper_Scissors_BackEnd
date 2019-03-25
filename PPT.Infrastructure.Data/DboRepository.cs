using PPT.Domain.Core;
using PPT.Domain.Core.Entities;
using PPT.Infrastructure.Core;
using System;
using System.Data.Entity.Infrastructure;


namespace PPT.Infrastructure.Data
{
    public class DboRepository<TEntity> : Repository<TEntity> where TEntity : BaseEntity
    {
        #region Constructor
        public DboRepository    (string setName, IUnitOfWork UnitOfWork) : base(setName, UnitOfWork)
        {
        }
        #endregion

#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public DbRawSqlQuery<TEntity> SQLQuery<TEntity>(string sql, params object[] parameters)
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            context.Database.CommandTimeout = 500;
            return context.Database.SqlQuery<TEntity>(sql, parameters);
        }

        public void SQLCommand(String sql, params object[] parameters)
        {
            context.Database.CommandTimeout = 500;
            context.Database.ExecuteSqlCommand(sql, parameters);
        }
    }
}
