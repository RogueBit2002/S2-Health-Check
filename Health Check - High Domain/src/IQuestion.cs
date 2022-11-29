using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain.High
{
    public interface IQuestion
    {
        public uint ID { get; }
        public string Text { get; }
    }
}
