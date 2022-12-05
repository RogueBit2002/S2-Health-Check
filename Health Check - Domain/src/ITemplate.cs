using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain
{
    public interface ITemplate
    {
        public uint ID { get; }
        public string Name { get; }
        
        public IEnumerable<uint> QuestionIDs { get; }
    }
}
