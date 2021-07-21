using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManagerClient.Client;
using MetricsManagerClient.Models;
using MetricsManagerClient.Requests;
using Prism.Commands;
using Prism.Mvvm;

namespace MetricsManagerClient.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IMetricsAgentClient _agentClient;

        private int _agentId;
        public int AgentId
        {
            get => _agentId;
            set => _agentId = value;
        }

        private int _value;
        public int Value
        {
            get => _value;
            set => _value = value;
        }

        private DateTimeOffset _time;
        public DateTimeOffset Time
        {
            get => _time;
            set => _time = value;
        }
        public DateTimeOffset FromTime { get; set; }
        public DateTimeOffset ToTime { get; set; }
        public ObservableCollection<CpuMetric> Metrics { get; private set; } = new();


        public MainWindowViewModel(IMetricsAgentClient agentClient)
        {
            _agentClient = agentClient;
        }

        private DelegateCommand _command = null;
        public DelegateCommand Command => _command ??= new DelegateCommand(GetCpuMetrics);

        private void GetCpuMetrics()
        {
            var metric = new CpuMetric();

            var response = _agentClient.GetAllCpuMetrics(new CpuMetricsApiRequest
            {
                FromTime = FromTime,
                ToTime = ToTime
            });

            foreach (var responseMetric in response.Metrics)
            {
                Metrics.Add(new CpuMetric
                {
                     AgentId = responseMetric.AgentId,
                     Time = responseMetric.Time,
                     Value = responseMetric.Value
                });
            }
        }
    }
}
