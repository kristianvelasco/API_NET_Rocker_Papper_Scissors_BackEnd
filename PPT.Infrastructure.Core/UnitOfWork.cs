using PPT.Domain.Core;
using PPT.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace PPT.Infrastructure.Core
{
    [DbConfigurationType(typeof(UnitOfWorkConfiguration))]
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        #region Fields

        protected string schema;

        #endregion

        #region Constructors

        static UnitOfWork()
        {
            Database.SetInitializer<DbContext>(null);
        }

        public UnitOfWork(string connectionStringName, string schema)
            : base("name=" + connectionStringName)
        {
            Database.SetInitializer<DbContext>(null);
            this.schema = schema;
            this.Initialize();
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        #endregion

        #region Methods

        protected void Initialize()
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual void Commit()
        {
            int trys = 0;
            do
            {
                try
                {
                    base.SaveChanges();
                    return;
                }
                catch (Exception ex)
                {
                    trys++;
                    if (trys > 4)
                    {
#pragma warning disable S3445 // Exceptions should not be explicitly rethrown
                        throw ex;
#pragma warning restore S3445 // Exceptions should not be explicitly rethrown
                    }
                }
            } while (trys < 5);
        }
        #endregion
    }

    public class UnitOfWorkConfiguration : DbConfiguration
    {
        public UnitOfWorkConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy(3, new TimeSpan(10)));
        }
    }
}
