using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Models;
using MetricsManager.DAL.Models.ApiModels;
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

			CreateMap<CpuMetricApiModel, CpuMetric>()
				.ForMember(dest => dest.Time,
				act => act.MapFrom(src => src.Time.ToUnixTimeSeconds()));
			CreateMap<CpuMetric, CpuMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));

			CreateMap<DotNetMetricApiModel, DotNetMetric>()
				.ForMember(dest => dest.Time,
				act => act.MapFrom(src => src.Time.ToUnixTimeSeconds()));
			CreateMap<DotNetMetric, DotNetMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));

			CreateMap<HddMetricApiModel, HddMetric>()
				.ForMember(dest => dest.Time,
				act => act.MapFrom(src => src.Time.ToUnixTimeSeconds()));
			CreateMap<HddMetric, HddMetricDto>()
				.ForMember(dest => dest.Time,
					act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));

			CreateMap<NetworkMetricApiModel, NetworkMetric>()
				.ForMember(dest => dest.Time,
				act => act.MapFrom(src => src.Time.ToUnixTimeSeconds()));
			CreateMap<NetworkMetric, NetworkMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));

			CreateMap<RamMetricApiModel, RamMetric>()
				.ForMember(dest => dest.Time,
				act => act.MapFrom(src => src.Time.ToUnixTimeSeconds()));
			CreateMap<RamMetric, RamMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
	    }
    }
}
