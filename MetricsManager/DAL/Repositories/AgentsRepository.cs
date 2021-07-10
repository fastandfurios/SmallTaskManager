using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Repositories.Connection;

namespace MetricsManager.DAL.Repositories
{
    public class AgentsRepository : IAgentsRepository
    {
	    private readonly IConnection _connection;

	    public AgentsRepository(IConnection connection)
	    {
		    _connection = connection;
			SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
	    }

	    public void Create(Models.Agents item)
	    {
			using var connection = _connection.GetOpenedConnection();

			connection.Execute("INSERT INTO agents(agentId, agentUrl) VALUES(@agentId, @agentUrl)",
				new
				{
					agentId = item.AgentId,
					agentUrl = item.AgentUrl
				});
		}

	    public IList<Models.Agents> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
	    {
		    throw new NotImplementedException();
	    }
    }
}
