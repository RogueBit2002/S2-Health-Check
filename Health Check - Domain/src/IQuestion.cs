using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain
{
    public interface IQuestion
    {
        public uint ID { get; }
        public uint TemplateID { get; }
        public string Header { get; }
        public string Description { get; }
        
    }
}
