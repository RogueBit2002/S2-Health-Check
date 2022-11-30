using HetBetereGroepje.HealthCheck.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.IData
{
    public interface ITemplateDataService
    {
        public ITemplate CreateTemplate(string name);
        public ITemplate GetTemplate(uint id);
    }
}
