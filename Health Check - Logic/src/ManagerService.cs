
using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.Factory;
using HetBetereGroepje.HealthCheck.IData;
using HetBetereGroepje.HealthCheck.ILogic;

namespace HetBetereGroepje.HealthCheck.Logic
{
    public class ManagerService : IManagerService
    {
        [ServiceFactory]
        private static IManagerService CreateService()
        {
            return new ManagerService(ServiceFactory.Create<IManagerDataService>());
        }


        private IManagerDataService dataService;

        private ManagerService(IManagerDataService dataService)
        {
            this.dataService = dataService;
        }

        public void Dispose()
        {
            dataService.Dispose();
        }


        public IManager GetManager(uint id) => dataService.GetManager(id);

        public IManager GetManager(string email) => dataService.GetManager(email);


        public bool TryLogin(string email, string password, out uint id)
        {
            id = 0;
            IManager user = dataService.GetManager(email);
            if (user == null)
                return false;

            id = user.ID;
            return user.Password == Cryptography.Hash(password);
        }


        public void Dispose()
        {
            dataService.Dispose();
        }
    }
}
