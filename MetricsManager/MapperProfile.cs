using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Models;
using MetricsManager.Responses.DTO;

namespace MetricsManager
{
    public class MapperProfile : Profile
    {
	    public MapperProfile()
	    {
		    CreateMap<DAL.Models.Agents, AgentsDto>()
			    .ForMember(dest => dest.AgentUrl,
				    act => act.MapFrom(src => src.AgentUrl));
		    CreateMap<CpuMetric, CpuMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
		    CreateMap<DotNetMetric, DotNetMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
		    CreateMap<HddMetric, HddMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
		    CreateMap<NetworkMetric, NetworkMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
		    CreateMap<RamMetric, RamMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
	    }
    }
}
