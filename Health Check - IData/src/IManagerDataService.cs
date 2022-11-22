using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HetBetereGroepje.HealthCheck.Domain.Low;

namespace HetBetereGroepje.HealthCheck.IData
{
    public interface IManagerDataService: IDisposable
    {
        public IManagerLow GetManager(uint id);
        public IManagerLow GetManager(string email);
    }
}
