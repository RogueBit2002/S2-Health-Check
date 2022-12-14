using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.Factory;
using HetBetereGroepje.HealthCheck.IData;
using HetBetereGroepje.HealthCheck.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Logic
{
    public class HealthCheckService : IHealthCheckService
    {
        [ServiceFactory]
        private static IHealthCheckService CreateService()
        {
            return new HealthCheckService(ServiceFactory.Create<IHealthCheckDataService>());
        }


        private IHealthCheckDataService dataService;

        private HealthCheckService(IHealthCheckDataService dataService)
        {
            this.dataService = dataService;
        }

        public IHealthCheck CreateHealthCheck(uint ownerId, uint templateId, string name)
        {
            return dataService.CreateHealthCheck(
                ownerId,
                templateId,
                Guid.NewGuid().ToString("N"),
                name);
        }

        public IHealthCheck GetHealthCheck(string hash) => dataService.GetHealthCheck(hash);

        public IEnumerable<IHealthCheck> GetHealthChecksByManager(uint managerId) => dataService.GetHealthChecksByManager(managerId);
        public void Dispose() => dataService.Dispose();
    }
}