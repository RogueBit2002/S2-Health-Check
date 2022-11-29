using HetBetereGroepje.HealthCheck.Data.Entities;
using HetBetereGroepje.HealthCheck.Domain.High;
using HetBetereGroepje.HealthCheck.IData;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data
{
    public class QuestionDataService : IQuestionDataService
    {

        private MySqlConnection connection;
        public QuestionDataService()
        {
            connection = DatabaseConnectionFactory.CreateConnection();
        }
        public IQuestion GetQuestion(uint id)
        {
            string query = "SELECT * FROM `question` WHERE `id`=@id;";


            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                return null;
            }

            Question question = new Question(id, reader.GetString("text"));

            return question;
        }
    }
}
