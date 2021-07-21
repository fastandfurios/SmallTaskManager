using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerClient.DTO
{
    public class NetworkMetricDto
    {
        public int AgentId { get; set; }
        public int Value { get; set; }
        public string Time { get; set; }
    }
}
