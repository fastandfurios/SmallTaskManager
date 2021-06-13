using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class AgentInfo
    {
	    public int AgentId { get; }
	    public Uri AgentAddress { get; }

	    public int AgentIdTest { get; } = 10;
	    public Uri AgentAddressTest { get; } = new Uri("https://github.com");
    }
}
