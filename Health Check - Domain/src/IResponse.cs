using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain
{
    public interface IResponse
    {
        public string Email { get; }
        public uint Id { get; }
        public uint HealthCheckId { get;  }
        IEnumerable<IAnswer> Answers { get; }
    }
}
