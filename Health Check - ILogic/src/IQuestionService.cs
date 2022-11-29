using HetBetereGroepje.HealthCheck.Domain.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.ILogic
{
    public interface IQuestionService
    {
        public IQuestion GetQuestion(uint id);
    }
}
