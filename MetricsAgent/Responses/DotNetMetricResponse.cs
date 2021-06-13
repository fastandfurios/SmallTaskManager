using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Responses.DTO;

namespace MetricsAgent.Responses
{
    public class DotNetMetricResponse
    {
	    public List<DotNetMetricDto> Metrics { get; set; }
    }
}
