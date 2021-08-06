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
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
		private readonly IConnection _connection;

        public CpuMetricsRepository(IConnection connection)
        {
			_connection = connection;
        }

		public void Create(CpuMetric item)
	    {
			using var connection = _connection.GetOpenedConnection();

			connection.Execute("INSERT INTO cpumetrics(agentId, value, time) VALUES(@agentId, @value, @time)",
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

			return connection.QuerySingle<DateTimeOffset>("SELECT ifnull(max(time),0) FROM cpumetrics");
		}

	    public IEnumerable<CpuMetric> GetMetricsFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
			using var connection = _connection.GetOpenedConnection();

			return connection
				.Query<CpuMetric>("SELECT id, agentId, value, time FROM cpumetrics WHERE time>=@fromTime AND time<=@toTime AND agentId = @agentId",
					new { agentId = agentId, fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() })
				.ToList();
		}

	    public IEnumerable<CpuMetric> GetMetricsFromAllCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
			using var connection = _connection.GetOpenedConnection();

			return connection
				.Query<CpuMetric>("SELECT id, agentId, value, time FROM cpumetrics WHERE time>=@fromTime AND time<=@toTime",
					new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() });
		}
    }
}
