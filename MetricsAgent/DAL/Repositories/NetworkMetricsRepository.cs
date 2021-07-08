using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Models;
using MetricsAgent.DAL.Repositories.Connection;

namespace MetricsAgent.DAL.Repositories
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
	    private readonly IConnection _connection;

	    public NetworkMetricsRepository(IConnection connection)
	    {
		    _connection = connection;
		    SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
	    }

	    public void Create(NetworkMetric item)
	    {
		    throw new NotImplementedException();
	    }

	    public IList<NetworkMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    using var connection = _connection.GetOpenedConnection();
			
				return connection.Query<NetworkMetric>("SELECT * FROM networkmetrics")
					.ToList();
	    }
    }
}
