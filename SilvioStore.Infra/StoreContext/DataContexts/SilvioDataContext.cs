using Dapper;
using System.Data;
using System.Data.SqlClient;
using System;
using SilvioStore.Shared;

namespace SilvioStore.Infra.StoreContext.DataContexts;

public class SilvioDataContext : IDisposable
{
    public SqlConnection Connection { get; set; }

    public SilvioDataContext()
    {
        Connection = new SqlConnection(Settings.ConnectionString);
        Connection.Open();
    }

    public void Dispose()
    {
        if (Connection.State != ConnectionState.Closed)
            Connection.Close();
    }
}



