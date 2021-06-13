using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Repositories.CpuMetricsRepository
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
	    private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

	    public void Create(CpuMetric item)
	    {
		    using var connection = new SQLiteConnection(ConnectionString);
			connection.Open();

			using var command = new SQLiteCommand(connection);
			command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(@value, @time)";
			command.Parameters.AddWithValue("@value", item.Value);
			command.Parameters.AddWithValue("@time", item.Time.Second);
			command.Prepare();
			command.ExecuteNonQuery();
	    }

	    public IList<CpuMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    using var connection = new SQLiteConnection(ConnectionString);
			connection.Open();

			using var command = new SQLiteCommand(connection);
			command.CommandText = "SELECT * FROM cpumetrics";

			var result = new List<CpuMetric>();

			using (SQLiteDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					result.Add(new CpuMetric
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
