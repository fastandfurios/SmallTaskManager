using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgent.Requests
{
    public class HddMetricCreateRequest
    {
	    public DateTimeOffset Time { get; set; }
	    public int Value { get; set; }
    }
}
