using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.DAL.Models.ApiModels;
using MetricsManager.Responses.DTO;

namespace MetricsManager.Responses.ApiResponses
{
    public class AllNetworkMetricsApiResponse
    {
        public List<NetworkMetricApiModel> Metrics { get; set; }
    }
}
