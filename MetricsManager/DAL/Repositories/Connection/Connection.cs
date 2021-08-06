using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Repositories.Connection
{
    internal class Connection : IConnection
    {
	    private readonly string _connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public SQLiteConnection GetOpenedConnection()
            => new SQLiteConnection(_connectionString);
    }
}
