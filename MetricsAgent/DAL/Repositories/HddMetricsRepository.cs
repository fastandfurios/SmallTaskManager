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
    public class HddMetricsRepository : IHddMetricsRepository
    {
	    private readonly IConnection _connection;

	    public HddMetricsRepository(IConnection connection)
	    {
		    _connection = connection;
		    SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
	    }

	    public void Create(HddMetric item)
	    {
			using var connection = _connection.GetOpenedConnection();

			connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)",
				new
				{
					value = item.Value,
					time = item.Time
				});
		}

	    public IList<HddMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    using var connection = _connection.GetOpenedConnection();

		    return connection
			    .Query<HddMetric>("SELECT id, value, time FROM hddmetrics WHERE time>=@fromTime AND time<=@toTime",
				    new {fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds()})
			    .ToList();
	    }
    }
}
