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
				    act => act.MapFrom(src => src.Time.ToString("s")));
            CreateMap<DotNetMetric, DotNetMetricDto>()
                .ForMember(dest => dest.Time,
                    act => act.MapFrom(src => src.Time.ToString("s")));
            CreateMap<HddMetric, HddMetricDto>()
                .ForMember(dest => dest.Time,
                    act => act.MapFrom(src => src.Time.ToString("s")));
            CreateMap<NetworkMetric, NetworkMetricDto>()
                .ForMember(dest => dest.Time,
                    act => act.MapFrom(src => src.Time.ToString("s")));
            CreateMap<RamMetric, RamMetricDto>()
                .ForMember(dest => dest.Time,
                    act => act.MapFrom(src => src.Time.ToString("s")));
        }
    }
}
