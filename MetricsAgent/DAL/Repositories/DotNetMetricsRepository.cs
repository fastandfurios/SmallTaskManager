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

	    public void Create(DotNetMetric item)
	    {
			using var connection = _connection.GetOpenedConnection();

			connection.Execute("INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)",
				new
				{
					value = item.Value,
					time = item.Time
				});
		}

	    public IList<DotNetMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    using var connection = _connection.GetOpenedConnection();
			    
			    return connection.Query<DotNetMetric>("SELECT id, value, time FROM dotnetmetrics WHERE time>=@fromTime AND time<=@toTime",
					    new
					    {
						    fromTime = fromTime.ToUnixTimeSeconds(),
						    toTime = toTime.ToUnixTimeSeconds()
						})
				    .ToList();
	    }
    }
}
