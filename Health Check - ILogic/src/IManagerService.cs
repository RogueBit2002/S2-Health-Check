using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HetBetereGroepje.HealthCheck.Domain;

namespace HetBetereGroepje.HealthCheck.ILogic
{
    public interface IManagerService: IDisposable
    {
        public IManager GetManager(uint id);
        public IManager GetManager(string email);

        public bool TryLogin(string email, string password, out uint id);
    }
}
