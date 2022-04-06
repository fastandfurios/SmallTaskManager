using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManagerClient.Models;

namespace MetricsManagerClient.Responses.ApiResponses
{
    public class NetworkMetricsApiResponse
    {
        public List<NetworkMetric> Metrics { get; set; }
    }
}
