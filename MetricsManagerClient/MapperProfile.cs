using System;
using AutoMapper;
using MetricsManagerClient.DTO;
using MetricsManagerClient.Models;

namespace MetricsManagerClient
{
    public class MapperProfile : Profile
    {
	    public MapperProfile()
	    {
		    CreateMap<CpuMetric, CpuMetricDto>()
			    .ForMember(dest => dest.Time,
				    act => act.MapFrom(src => src.Time.ToString("hh:mm:ss MM/dd/yyyy")));
            CreateMap<DotNetMetric, DotNetMetricDto>()
                .ForMember(dest => dest.Time,
                    act => act.MapFrom(src => src.Time.ToString("hh:mm:ss MM/dd/yyyy")));
            CreateMap<HddMetric, HddMetricDto>()
                .ForMember(dest => dest.Time,
                    act => act.MapFrom(src => src.Time.ToString("hh:mm:ss MM/dd/yyyy")));
            CreateMap<NetworkMetric, NetworkMetricDto>()
                .ForMember(dest => dest.Time,
                    act => act.MapFrom(src => src.Time.ToString("hh:mm:ss MM/dd/yyyy")));
            CreateMap<RamMetric, RamMetricDto>()
                .ForMember(dest => dest.Time,
                    act => act.MapFrom(src => src.Time.ToString("hh:mm:ss MM/dd/yyyy")));
        }
    }
}
