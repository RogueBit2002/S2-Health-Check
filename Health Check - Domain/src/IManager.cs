using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain
{
    public interface IManager
    {
        public uint ID { get; }
        public string Email { get; }
        
        public string Password { get; } //Temporary
    }
}
