using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager.Requests.ApiRequests
{
    public class GetAllNetworkMetricsApiRequest
    {
	    public Uri ClientBaseAddress { get; set; }
	    public DateTimeOffset FromTime { get; set; }
	    public DateTimeOffset ToTime { get; set; }
    }
}
