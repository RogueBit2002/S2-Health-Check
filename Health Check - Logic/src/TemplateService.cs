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
    internal class TemplateService : ITemplateService
    {
        [ServiceFactory]
        private static ITemplateService CreateService()
        {
            return new TemplateService(ServiceFactory.Create<ITemplateDataService>());
        }

        private ITemplateDataService templateDataService;

        public TemplateService(ITemplateDataService templateDataService)
        {
            this.templateDataService = templateDataService;
        }

        public void Dispose()
        {
            templateDataService.Dispose();
        }

        public ITemplate CreateTemplate(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"{name} isn't a valid name");

            return templateDataService.CreateTemplate(name);
        }

        public ITemplate GetTemplate(uint id) => templateDataService.GetTemplate(id);

        public IEnumerable<ITemplate> GetTemplates() => templateDataService.GetTemplates();

        
    }
}
