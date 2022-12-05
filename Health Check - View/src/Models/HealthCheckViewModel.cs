using HetBetereGroepje.HealthCheck.Domain;

namespace HetBetereGroepje.HealthCheck.View.Models
{
    public class HealthCheckViewModel
    {
        public IHealthCheck healthCheck;
        public IEnumerable<IQuestion> questions;

        public HealthCheckViewModel(IHealthCheck healthCheck, IEnumerable<IQuestion> questions)
        {
            this.healthCheck = healthCheck;
            this.questions = questions;
        }
    }
}
