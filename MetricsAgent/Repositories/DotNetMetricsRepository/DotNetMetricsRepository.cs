using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;
using MetricsAgent.Responses.DTO;

namespace MetricsAgent.Repositories.DotNetMetricsRepository
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
	    private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

		public void Create(DotNetMetric item)
	    {
		    
	    }

	    public IList<DotNetMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
			using var connection = new SQLiteConnection(ConnectionString);
			connection.Open();

			using var command = new SQLiteCommand(connection);
			command.CommandText = "SELECT * FROM cpumetrics";

			var result = new List<DotNetMetric>();

			using (SQLiteDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					result.Add(new DotNetMetric()
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
