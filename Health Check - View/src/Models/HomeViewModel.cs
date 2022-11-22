using HetBetereGroepje.HealthCheck.Domain.High;

namespace HetBetereGroepje.HealthCheck.View.Models
{
    public class HomeViewModel
    {
        public string absoluteUri;
        public string redirect;
        public string name;
        public IEnumerable<IHealthCheck> healthChecks;

        public HomeViewModel(string absoluteUri, IEnumerable<IHealthCheck> healthChecks)
        {
            this.absoluteUri = absoluteUri;
            this.healthChecks = healthChecks;
        }
    }
}
