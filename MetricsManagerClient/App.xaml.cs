using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using MetricsManagerClient.Client;
using MetricsManagerClient.ViewModels;
using MetricsManagerClient.Views;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Prism.Ioc;
using Prism.Unity;

namespace MetricsManagerClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            containerRegistry.RegisterInstance(mapperConfiguration.CreateMapper());

            containerRegistry.RegisterSingleton<IMetricsAgentClient, MetricsAgentClient>();
        }

        protected override Window CreateShell()
            => Container.Resolve<MainWindow>();
    }
}
