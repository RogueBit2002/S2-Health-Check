using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Factory
{
    public static class QuestionFactory
    {
        public static IQuestionService CreateService()
        {
            return new QuestionService(CreateDataService());
        }

        public static IQuestionDataService CreateDataService()
        {
            return new QuestionDataService();
        }

    }
}
