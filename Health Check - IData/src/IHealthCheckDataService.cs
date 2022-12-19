using HetBetereGroepje.HealthCheck.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.IData
{
    public interface IHealthCheckDataService : IDisposable
    {
        public IHealthCheck CreateHealthCheck(string tenantId, uint templateId, string hash, string name);
        public IHealthCheck GetHealthCheck(uint id);
        public IHealthCheck GetHealthCheck(string hash);

        public IEnumerable<IHealthCheck> GetHealthChecksByTenant(string tenantId);

    }
}
