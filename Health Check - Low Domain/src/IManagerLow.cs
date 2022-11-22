using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HetBetereGroepje.HealthCheck.Domain.Low
{
    public interface IManagerLow: High.IManager
    {
        public string Password { get; }
    }
}
