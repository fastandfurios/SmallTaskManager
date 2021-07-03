using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.Repositories;
using MetricsAgent.Repositories.Connection;

namespace MetricsAgent.DAL.Repositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
	    private readonly IConnection _connection;

	    public CpuMetricsRepository(IConnection connection)
	    {
		    _connection = connection;
		    SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
	    }

	    public IList<CpuMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    using var connection = new SQLiteConnection(_connection.GetOpenedConnection());

		    return connection.Query<CpuMetric>("SELECT * FROM cpumetrics")
				    .Where(w => w.Time.Second >= fromTime.Second && w.Time.Second <= toTime.Second)
				    .ToList();
	    }
    }
}
