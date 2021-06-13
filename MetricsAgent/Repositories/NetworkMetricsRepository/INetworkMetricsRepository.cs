using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Repositories.NetworkMetricsRepository
{
    public interface INetworkMetricsRepository : IRepository<NetworkMetric>
    {
    }
}
