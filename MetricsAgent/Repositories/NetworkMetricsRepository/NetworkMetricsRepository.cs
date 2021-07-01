using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Repositories.NetworkMetricsRepository
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
	    private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

		public void Create(NetworkMetric item)
	    {
		    
	    }

	    public IList<NetworkMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    using var connection = new SQLiteConnection(ConnectionString);
		    connection.Open();

		    using var command = new SQLiteCommand(connection);
		    command.CommandText = "SELECT * FROM networkmetrics";

		    var result = new List<NetworkMetric>();

		    using (SQLiteDataReader reader = command.ExecuteReader())
		    {
			    while (reader.Read())
			    {
				    result.Add(new NetworkMetric()
				    {
					    Id = reader.GetInt32(0),
					    Value = reader.GetInt32(1),
					    Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(2))
				    });
			    }
		    }

		    return result.Where(w => w.Time.Second >= fromTime.Second && w.Time.Second <= toTime.Second).ToList();
		}
    }
}
