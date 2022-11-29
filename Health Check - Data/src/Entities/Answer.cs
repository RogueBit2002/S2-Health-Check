using HetBetereGroepje.HealthCheck.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data.Entities
{
    public class Answer : IAnswer
    {
        public uint QuestionId { get; set; }

        public IResponse Response { get; set; }

        public int Value { get; set; }

        public Answer(uint questionId, IResponse response, int value)
        {
            QuestionId = questionId;
            Response = response;
            Value = value;
        }
    }

    internal static partial class ReaderExtensions
    {
        public static Answer GetAnswer(this MySqlDataReader reader)
        {
            int value = reader.GetInt32("value");
            uint questionId = reader.GetUInt32("question_id");


            return new Answer(questionId, null, value);
        }
    }

}
