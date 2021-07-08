using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.DAL.Models;
using MetricsAgent.Responses.DTO;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
	    public MapperProfile()
	    {
		    CreateMap<CpuMetric, CpuMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
		    CreateMap<DotNetMetric, DotNetMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
		    CreateMap<HddMetric, HddMetricDto>();
		    CreateMap<NetworkMetric, NetworkMetricDto>();
		    CreateMap<RamMetric, RamMetricDto>();
	    }
    }
}
