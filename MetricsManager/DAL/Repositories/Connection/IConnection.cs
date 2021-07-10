using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Repositories.Connection
{
    public interface IConnection
    {
	    SQLiteConnection GetOpenedConnection();
    }
}
