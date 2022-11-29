using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Domain
{
    public interface IAnswer
    {
        public uint QuestionId { get; }
        public IResponse Response { get; }
        public int Value { get; }
    }
}
