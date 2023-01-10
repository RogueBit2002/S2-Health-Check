using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.IData;
using HetBetereGroepje.HealthCheck.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using HetBetereGroepje.HealthCheck.Data.Entities;

namespace HetBetereGroepje.HealthCheck.Data
{
    public class QuestionDataService : IQuestionDataService
    {
        [ServiceFactory]
        private static IQuestionDataService CreateService()
        {
            return new QuestionDataService();
        }

        private MySqlConnection connection;
        public QuestionDataService()
        {
            //connection = DatabaseConnectionFactory.CreateConnection();
        }

        public void Dispose()
        {
            //connection.Close();
            //connection.Dispose();
        }
        public IQuestion CreateQuestion(uint templateId, string header, string description)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = @"INSERT INTO `question`(`template_id`, `header`, `description`) VALUES
(@templateId, @header, @description);";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("templateId", templateId);
            command.Parameters.AddWithValue("header", header);
            command.Parameters.AddWithValue("description", description);

            command.ExecuteNonQuery();
            connection.Close();
            return GetQuestion((uint)command.LastInsertedId);
        }

        public IQuestion GetQuestion(uint id)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = "SELECT * FROM `question` WHERE `id`=@id;";


            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                return null;
            }

            Question question = reader.GetQuestion();

            reader.Close();
            connection.Close();
            return question;
        }

        public IEnumerable<IQuestion> GetQuestionsByTemplate(uint templateId)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = "SELECT * FROM `question` WHERE `template_id`=@id;";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("id", templateId);

            MySqlDataReader reader = command.ExecuteReader();

            List<Question> questions = new List<Question>();

            while(reader.Read())
                questions.Add(reader.GetQuestion());

            reader.Close();
            connection.Close();
            return questions.AsReadOnly();
        }
    }
}
