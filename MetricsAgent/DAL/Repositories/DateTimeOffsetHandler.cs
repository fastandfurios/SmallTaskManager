using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MetricsAgent.DAL.Repositories
{
    public class DateTimeOffsetHandler : SqlMapper.TypeHandler<DateTimeOffset>
    {
	    public override void SetValue(IDbDataParameter parameter, DateTimeOffset value)
	    {
		    parameter.Value = value;
	    }

	    public override DateTimeOffset Parse(object value)
	    {
		    return DateTimeOffset.FromUnixTimeSeconds((int)value);
	    }
    }
}
