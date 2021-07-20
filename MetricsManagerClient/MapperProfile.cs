using AutoMapper;
using MetricsManagerClient.DTO;
using MetricsManagerClient.Models;

namespace MetricsManagerClient
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetricDto, CpuMetric>();
        }
    }
}
