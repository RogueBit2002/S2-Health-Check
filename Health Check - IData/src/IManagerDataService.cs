using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HetBetereGroepje.HealthCheck.Domain;

namespace HetBetereGroepje.HealthCheck.IData
{
    public interface IManagerDataService: IDisposable
    {
        public IManager GetManager(uint id);
        public IManager GetManager(string email);
    }
}
