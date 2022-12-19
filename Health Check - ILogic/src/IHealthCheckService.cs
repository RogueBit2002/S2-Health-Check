using HetBetereGroepje.HealthCheck.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.ILogic
{
    public interface IHealthCheckService : IDisposable
    {
        public IHealthCheck CreateHealthCheck(string tenantId, uint templateId, string name);
        public IHealthCheck GetHealthCheck(string hash);
        //public IEnumerable<IHealthCheck> GetHealthChecksByManager(IManager manager) => GetHealthChecksByManager(manager.ID);
        public IEnumerable<IHealthCheck> GetHealthChecksByTenant(string tenantId);
        
    }
}
