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
    public class ResponseService : IResponseService
    {

        [ServiceFactory]
        private static IResponseService CreateService()
        {
            return new ResponseService(ServiceFactory.Create<IResponseDataService>());
        }

        public IResponse CreateResponse(uint healthCheckId, string email, IReadOnlyDictionary<uint, int> answers)
        {
            return responseDataService.CreateResponse(healthCheckId, email, answers);
        }

        public IEnumerable<IResponse> GetAllResponses(uint healthCheckId)
        {
            return responseDataService.GetAllResponses(healthCheckId);
        }

        public IResponse GetResponse(uint id)
        {
            return responseDataService.GetResponse(id);
        }

        private IResponseDataService responseDataService;

        public ResponseService(IResponseDataService responseDataService)
        {
            this.responseDataService = responseDataService;
        }


        public void Dispose()
        {
            responseDataService.Dispose();
        }
    }
}
