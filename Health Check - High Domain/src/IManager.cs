using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain.High
{
    public interface IManager : IEntity
    {
        public string Email { get; }
    }
}
