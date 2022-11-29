using HetBetereGroepje.HealthCheck.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.ILogic
{
    public interface IResponseService 
    {
        public IResponse CreateResponse(uint healthCheckId, string email, IReadOnlyDictionary<uint, int> answers);
        public IResponse GetResponse(uint id);
        public IEnumerable<IResponse> GetAllResponses(uint healthCheckId);
    }
}
