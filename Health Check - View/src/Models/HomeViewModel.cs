using HetBetereGroepje.HealthCheck.Domain;

namespace HetBetereGroepje.HealthCheck.View.Models
{
    public class HomeViewModel
    {
        public string absoluteUri;
        public string redirect;
        public string name;
        public Dictionary<IHealthCheck, IEnumerable<IResponse>> healthChecks;

        public HomeViewModel(string absoluteUri, Dictionary<IHealthCheck, IEnumerable<IResponse>> healthCheckResultDictionary)
        {
            this.absoluteUri = absoluteUri;
            this.healthChecks = healthCheckResultDictionary;
        }
    }
}
