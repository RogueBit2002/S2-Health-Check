using HetBetereGroepje.HealthCheck.Domain.High;

namespace HetBetereGroepje.HealthCheck.View.Models
{
    public class HealthCheckViewModel
    {
        public IHealthCheck healthCheck;


        public HealthCheckViewModel(IHealthCheck healthCheck)
        {
            this.healthCheck = healthCheck;
        }
    }
}
