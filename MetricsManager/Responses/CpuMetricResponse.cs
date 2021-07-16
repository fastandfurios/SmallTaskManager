using System.Collections.Generic;
using MetricsManager.Responses.DTO;

namespace MetricsManager.Responses
{
    public class CpuMetricResponse
    {
	    public List<CpuMetricDto> Metrics { get; set; }
    }
}
