using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MetricsManagerClient.Client;
using MetricsManagerClient.Views;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace MetricsManagerClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            

            var maperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            services.AddSingleton(maperConfiguration.CreateMapper());

            services.AddHttpClient<IMetricsAgentClient, MetricsAgentClient>()
                .AddTransientHttpErrorPolicy(p =>
                    p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000)));
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
