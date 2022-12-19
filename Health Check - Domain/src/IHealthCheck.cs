using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain
{
    public interface IHealthCheck
    {
        public uint ID { get; }

        public string Hash { get; }

        public string OwnerID { get; }
        public uint TemplateID { get; }
        public string Name { get; }
    }
}
