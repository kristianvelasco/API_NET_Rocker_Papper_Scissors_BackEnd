using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPT.Domain.Core;
using System.Configuration;


namespace PPT.Application.Core
{
    public class Service:IService
    {
            
        #region Properties

        public string ConnectionStringName { get; set; }
        public string Schema { get; set; }
        public string ProviderName { get { return providerName; } }
        public bool SharedTransaction { get { return sharedTransaction; } }

        #endregion

        #region Fields

        protected virtual IUnitOfWork UnitOfWork { get; set; }
        private string providerName;
        protected bool sharedTransaction { get; set; }

        #endregion 

        #region Methods

        public void BeginSharedTransaction()
        {
            this.sharedTransaction = true;
        }

        public void Initialize()
        {
            if (string.IsNullOrEmpty(ConnectionStringName))
                throw new Exception("The ConnectionString Name property has not been initialized.");

            this.providerName = ConfigurationManager.ConnectionStrings[ConnectionStringName].ProviderName;
            this.sharedTransaction = false;
        }


        public void Commit()
        {
            if (this.sharedTransaction)
            {
                this.UnitOfWork.Commit();
                this.sharedTransaction = false;
            }
            else
            {
                throw new Exception("Cannot call commit action when a shared transaction is not running.");
            }
        }
        #endregion
    }
}
