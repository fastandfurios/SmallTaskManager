using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.DAL.Repositories.Connection;

namespace MetricsManager.DAL.Repositories
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
		private IConnection _connection;

        public NetworkMetricsRepository(IConnection connection)
        {
			_connection = connection;
        }

	    public void Create(NetworkMetric item)
	    {
			using var connection = _connection.GetOpenedConnection();

			connection.Execute("INSERT INTO networkmetrics(agentId, value, time) VALUES(@agentId, @value, @time)",
				new
				{
					agentId = item.AgentId,
					value = item.Value,
					time = item.Time
				});
		}

	    public DateTimeOffset GetMaxDate()
	    {
			using var connection = _connection.GetOpenedConnection();

			return connection.QuerySingle<DateTimeOffset>("SELECT ifnull(max(time),0) FROM hddmetrics");
		}

	    public IList<NetworkMetric> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
			using var connection = _connection.GetOpenedConnection();

			return connection
				.Query<NetworkMetric>("SELECT id, agentId, value, time FROM hddmetrics WHERE time>=@fromTime AND time<=@toTime AND agentId = @agentId",
					new { agentId = agentId, fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() })
				.ToList();
		}

	    public IList<NetworkMetric> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
			using var connection = _connection.GetOpenedConnection();

			return connection
				.Query<NetworkMetric>("SELECT id, agentId, value, time FROM hddmetrics WHERE time>=@fromTime AND time<=@toTime",
					new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() })
				.ToList();
		}
    }
}
