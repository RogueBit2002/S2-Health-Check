using HetBetereGroepje.HealthCheck.Domain.High;
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
    public class QuestionService : IQuestionService
    {
        [ServiceFactory]
        private static IQuestionService CreateService()
        {
            return new QuestionService(ServiceFactory.Create<IQuestionDataService>());
        }
        
        private IQuestionDataService dataService;
        public QuestionService(IQuestionDataService dataService)
        {
            this.dataService = dataService;
        }

        
        public IQuestion GetQuestion(uint id)
        {
            return dataService.GetQuestion(id);
        }
    }
}
