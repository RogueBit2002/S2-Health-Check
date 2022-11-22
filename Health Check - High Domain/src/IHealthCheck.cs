using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain.High
{
    public interface IHealthCheck : IEntity
    {
        public string Hash { get; set; }
        public uint OwnerID { get; set; }
        public string Name { get; set; }
    }
}
