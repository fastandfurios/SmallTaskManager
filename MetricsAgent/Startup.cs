using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Controllers;
using MetricsAgent.Repositories.CpuMetricsRepository;
using MetricsAgent.Repositories.DotNetMetricsRepository;
using MetricsAgent.Repositories.HddMetricsRepository;
using MetricsAgent.Repositories.NetworkMetricsRepository;
using MetricsAgent.Repositories.RamMetricsRepository;

namespace MetricsAgent
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			ConfigureSqlLiteConnection();
			services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
			services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
			services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
			services.AddSingleton<INetworkMetricsRepository, NetworkMetricsRepository>();
			services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();
		}

		private void ConfigureSqlLiteConnection()
		{
			const string connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
			var connection = new SQLiteConnection(connectionString);
			connection.Open();
			PrepareSchema(connection);
		}

		private void PrepareSchema(SQLiteConnection connection)
		{
			using (var command = new SQLiteCommand(connection))
			{
				command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
				command.ExecuteNonQuery();

				command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
				command.ExecuteNonQuery();

				command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(10, 1)";
				command.ExecuteNonQuery();

				command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(50, 2)";
				command.ExecuteNonQuery();

				command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(75, 4)";
				command.ExecuteNonQuery();

				command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(90, 5)";
				command.ExecuteNonQuery();
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
