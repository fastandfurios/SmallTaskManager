using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.Responses.DTO;

namespace MetricsManager.Responses.ApiResponses
{
    public class DotNetMetricsApiResponse
    {
	    public List<DotNetMetricDto> Metrics { get; set; }
    }
}
