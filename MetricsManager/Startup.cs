using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using FluentMigrator.Runner;
using MetricsManager.Client;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Repositories;
using MetricsManager.DAL.Repositories.Connection;
using MetricsManager.Jobs;
using MetricsManager.QuartzService;
using Microsoft.Extensions.Logging;
using Polly;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace MetricsManager
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSingleton<IAgentsRepository, AgentsRepository>();
			services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
			services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
			services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
			services.AddSingleton<INetworkMetricsRepository, NetworkMetricsRepository>();
			services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();

			services.AddSingleton<IConnection, Connection>();

			var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
			services.AddSingleton(mapperConfiguration.CreateMapper());

			services.AddFluentMigratorCore()
				.ConfigureRunner(rb => rb.AddSQLite()
					.WithGlobalConnectionString(ConnectionString)
					.ScanIn(typeof(Startup).Assembly).For.Migrations())
				.AddLogging(lb => lb.AddFluentMigratorConsole());

			services.AddSingleton<IJobFactory, SingletonJobFactory>();
			services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

			services.AddSingleton<HddMetricJob>();
			services.AddSingleton(new JobSchedule(
				jobType: typeof(HddMetricJob),
				cronExpression: "0/5 * * * * ?"));

			services.AddHostedService<QuartzHostedService>();

			services.AddHttpClient<IMetricsAgentClient, MetricsAgentClient>()
				.AddTransientHttpErrorPolicy(p =>
					p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000)));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
		{
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			migrationRunner.MigrateUp();
		}
	}
}
