using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManagerClient.Client;
using MetricsManagerClient.DTO;
using MetricsManagerClient.Models;
using MetricsManagerClient.Requests;
using Prism.Commands;
using Prism.Mvvm;

namespace MetricsManagerClient.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IMetricsAgentClient _agentClient;
        private readonly IMapper _mapper;
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public ObservableCollection<CpuMetricDto> CpuMetrics { get; private set; } = new();
        public ObservableCollection<DotNetMetricDto> DotNetMetrics { get; private set; } = new();
        public ObservableCollection<HddMetricDto> HddMetrics { get; private set; } = new();
        public ObservableCollection<NetworkMetricDto> NetworkMetrics { get; private set; } = new();
        public ObservableCollection<RamMetricDto> RamMetrics { get; private set; } = new();

        public MainWindowViewModel(IMetricsAgentClient agentClient, IMapper mapper)
        {
            _agentClient = agentClient;
            _mapper = mapper;
        }

        private DelegateCommand<string> _command = null;
        public DelegateCommand<string> Command => _command ??= new DelegateCommand<string>(GetMetrics);
        
        private void GetMetrics(string parameter)
        {
            switch (parameter)
            {
                case "CpuCommand":
                    GetCpuMetrics();
                    break;
                case "NETCommand":
                    GetDotNetMetrics();
                    break;
                case "HddCommand":
                    GetHddMetrics();
                    break;
                case "NetworkCommand":
                    GetNetworkMetrics();
                    break;
                case "RamCommand":
                    GetRamMetrics();
                    break;
            }
        }

        private void GetCpuMetrics()
        {
            var metric = new CpuMetricDto();

            var response = _agentClient.GetAllCpuMetrics(new CpuMetricsApiRequest
            {
                FromTime = DateTimeOffset.Parse(FromTime),
                ToTime = DateTimeOffset.Parse(ToTime)
            });

            foreach (var responseMetric in response.Metrics)
            {
                CpuMetrics.Add(_mapper.Map<CpuMetricDto>(responseMetric));
            }
        }

        private void GetDotNetMetrics()
        {
            var metric = new DotNetMetricDto();

            var response = _agentClient.GetAllDotNetMetrics(new DotNetMetricsApiRequest()
            {
                FromTime = DateTimeOffset.Parse(FromTime),
                ToTime = DateTimeOffset.Parse(ToTime)
            });

            foreach (var responseMetric in response.Metrics)
            {
                DotNetMetrics.Add(_mapper.Map<DotNetMetricDto>(responseMetric));
            }
        }

        private void GetHddMetrics()
        {
            var metric = new HddMetricDto();

            var response = _agentClient.GetAllHddMetrics(new HddMetricsApiRequest()
            {
                FromTime = DateTimeOffset.Parse(FromTime),
                ToTime = DateTimeOffset.Parse(ToTime)
            });

            foreach (var responseMetric in response.Metrics)
            {
                HddMetrics.Add(_mapper.Map<HddMetricDto>(responseMetric));
            }
        }

        private void GetNetworkMetrics()
        {
            var metric = new NetworkMetricDto();

            var response = _agentClient.GetAllNetworkMetrics(new NetworkMetricsApiRequest()
            {
                FromTime = DateTimeOffset.Parse(FromTime),
                ToTime = DateTimeOffset.Parse(ToTime)
            });

            foreach (var responseMetric in response.Metrics)
            {
                NetworkMetrics.Add(_mapper.Map<NetworkMetricDto>(responseMetric));
            }
        }

        private void GetRamMetrics()
        {
            var metric = new RamMetricDto();

            var response = _agentClient.GetAllRamMetrics(new RamMetricsApiRequest()
            {
                FromTime = DateTimeOffset.Parse(FromTime),
                ToTime = DateTimeOffset.Parse(ToTime)
            });

            foreach (var responseMetric in response.Metrics)
            {
                RamMetrics.Add(_mapper.Map<RamMetricDto>(responseMetric));
            }
        }
    }
}
