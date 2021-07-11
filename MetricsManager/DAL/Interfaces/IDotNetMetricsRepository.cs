using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricsManager.DAL.Models;

namespace MetricsManager.DAL.Interfaces
{
    public interface IDotNetMetricsRepository : Core.Interfaces.IRepository<DotNetMetric>
    {
    }
}
