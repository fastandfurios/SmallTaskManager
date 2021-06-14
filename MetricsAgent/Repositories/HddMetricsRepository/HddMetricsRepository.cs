using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Repositories.HddMetricsRepository
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
	    private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

		public void Create(HddMetric item)
	    {
		    
	    }

	    public IList<HddMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
			using var connection = new SQLiteConnection(ConnectionString);
			connection.Open();

			using var command = new SQLiteCommand(connection);
			command.CommandText = "SELECT * FROM cpumetrics";

			var result = new List<HddMetric>();

			using (SQLiteDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					result.Add(new HddMetric()
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
