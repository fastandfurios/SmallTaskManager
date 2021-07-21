using System;
using System.Collections.Generic;
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

        public MainWindowViewModel(IMetricsAgentClient agentClient)
        {
            _agentClient = agentClient;
        }

        private DelegateCommand _command = null;
        public DelegateCommand Command => _command ??= new DelegateCommand(GetMetrics);

        private void GetMetrics()
        {
            var metric = new CpuMetric();

            var response = _agentClient.GetAllCpuMetrics(new CpuMetricsApiRequest
            {
                FromTime = DateTimeOffset.UtcNow,
                ToTime = DateTimeOffset.UtcNow
            });

            _agentId = 12;
            RaisePropertyChanged(nameof(AgentId));
            _time = DateTimeOffset.UtcNow;
            RaisePropertyChanged(nameof(Time));
            _value = 16;
            RaisePropertyChanged(nameof(Value));
        }
    }
}
