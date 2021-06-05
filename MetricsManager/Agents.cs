using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManager
{
    public sealed class Agents
    {
	    public List<AgentInfo> ListAgents;

	    public Agents() => ListAgents = new List<AgentInfo>();
    }
}
