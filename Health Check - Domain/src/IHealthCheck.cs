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
        public string Hash { get; set; }
        public uint OwnerID { get; set; }
        public string Name { get; set; }
    }
}
