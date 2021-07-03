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
using MetricsAgent.Responses.DTO;

namespace MetricsAgent.DAL.Repositories
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
	    private readonly IConnection _connection;

	    public DotNetMetricsRepository(IConnection connection)
	    {
		    _connection = connection;
		    SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
	    }

	    public IList<DotNetMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    using (var connection = new SQLiteConnection(_connection.GetOpenedConnection()))
			    
			    return connection.Query<DotNetMetric>("SELECT * FROM dotnetmetrics")
					.Where(w => w.Time.Second >= fromTime.Second && w.Time.Second <= toTime.Second)
					.ToList();
	    }
    }
}
