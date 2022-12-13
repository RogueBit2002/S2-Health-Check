using HetBetereGroepje.HealthCheck.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.ILogic
{
    public interface ITemplateService : IDisposable
    {
        public ITemplate CreateTemplate(string name);
        public ITemplate GetTemplate(uint id);
        public IEnumerable<ITemplate> GetTemplates();
        
    }
}
