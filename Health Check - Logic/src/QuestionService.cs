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
    public class QuestionService : IQuestionService
    {
        [ServiceFactory]
        private static IQuestionService CreateService()
        {
            return new QuestionService(
                ServiceFactory.Create<IQuestionDataService>(),
                ServiceFactory.Create<ITemplateDataService>());
        }

        private IQuestionDataService questionDataService;
        private ITemplateDataService templateDataService;
        public QuestionService(IQuestionDataService questionDataService, ITemplateDataService templateDataService)
        {
            this.questionDataService = questionDataService;
            this.templateDataService = templateDataService;
        }

        public IQuestion CreateQuestion(uint templateId, string header, string description)
        {
            if (templateDataService.GetTemplate(templateId) == null)
                throw new ArgumentException($"Template with id {templateId} doesn't exist");

            if(string.IsNullOrEmpty(header))
                throw new ArgumentException("Invalid header");

            return questionDataService.CreateQuestion(templateId, header, description);
        }

        public IQuestion GetQuestion(uint id) => questionDataService.GetQuestion(id);

        public IEnumerable<IQuestion> GetQuestionsByTemplate(uint templateId) => questionDataService.GetQuestionsByTemplate(templateId);
    }
}
