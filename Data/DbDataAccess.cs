using Services;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Data
{
    public abstract class DbDataAccess<T> : IDisposable
    {
        protected readonly DbProviderFactory factory;
        protected readonly DbConnection sqlConnection;
        public DbDataAccess()
        {
            factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            sqlConnection = factory.CreateConnection();
            sqlConnection.ConnectionString = ConfigurationService.Configuration["dataAccessConnectionString"];
            sqlConnection.Open();
        }
        public void Dispose()
        {
            sqlConnection.Close();
        }
        public abstract ICollection<T> Select(string select);
    }
}
