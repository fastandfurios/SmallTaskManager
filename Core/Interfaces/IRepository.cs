using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class 
    {
	    IList<T> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);
    }
}
