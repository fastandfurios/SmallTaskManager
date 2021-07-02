using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.Models;
using MetricsAgent.Responses.DTO;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
	    public MapperProfile()
	    {
		    CreateMap<CpuMetric, CpuMetricDto>();
		    CreateMap<DotNetMetric, DotNetMetricDto>();
		    CreateMap<HddMetric, HddMetricDto>();
		    CreateMap<NetworkMetric, NetworkMetricDto>();
		    CreateMap<RamMetric, RamMetricDto>();
	    }
    }
}
