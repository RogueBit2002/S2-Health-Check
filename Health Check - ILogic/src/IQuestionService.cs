using HetBetereGroepje.HealthCheck.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.ILogic
{
    public interface IQuestionService
    {
        public IQuestion CreateQuestion(uint templateId, string header, string description);

        public IQuestion GetQuestion(uint id);

        public IEnumerable<IQuestion> GetQuestionsByTemplate(uint templateId);
    }
}
