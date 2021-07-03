using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.Repositories.Connection;

namespace MetricsAgent.DAL.Repositories
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
	    private readonly IConnection _connection;

	    public HddMetricsRepository(IConnection connection)
	    {
		    _connection = connection;
		    SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
	    }

	    public IList<HddMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
			using (var connection = new SQLiteConnection(_connection.GetOpenedConnection()))
			
				return connection.Query<HddMetric>("SELECT * FROM hddmetrics")
					.Where(w => w.Time.Second >= fromTime.Second && w.Time.Second <= toTime.Second)
					.ToList();
	    }
    }
}
