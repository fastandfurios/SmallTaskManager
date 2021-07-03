using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using MetricsAgent.DAL.Models;

namespace MetricsAgent.DAL.Interfaces
{
    public interface IRamMetricsRepository : IRepository<RamMetric>
    {
    }
}
