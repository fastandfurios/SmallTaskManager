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
            containerRegistry.RegisterSingleton<IMetricsAgentClient, MetricsAgentClient>();

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            containerRegistry.RegisterInstance(mapperConfiguration.CreateMapper());
        }

        protected override Window CreateShell()
            => Container.Resolve<MainWindow>();
    }
}
