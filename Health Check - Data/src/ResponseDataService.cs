﻿using HetBetereGroepje.HealthCheck.Data.Entities;
using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.Factory;
using HetBetereGroepje.HealthCheck.IData;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HetBetereGroepje.HealthCheck.Data.src
{
    public class ResponseDataService : IResponseDataService
    {
        [ServiceFactory]
        private static IResponseDataService CreateService()
        {
            return new ResponseDataService();
        }

        private MySqlConnection connection;

        private ResponseDataService()
        {
            //connection = DatabaseConnectionFactory.CreateConnection();
        }

        public void Dispose()
        {
            //connection.Close();
            //connection.Dispose();
        }


        public IResponse CreateResponse(uint healthCheckId, string email, IReadOnlyDictionary<uint, int> answers)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = @"INSERT INTO `response`(`health_check_id`, `email`) VALUES (@healthCheckId, @email);";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("healthCheckId", healthCheckId);
            command.Parameters.AddWithValue("email", email);

            command.ExecuteNonQuery();

            uint responseId = (uint)command.LastInsertedId;

            foreach(uint key in answers.Keys)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `answer`(`response_id`,`question_id`,`value`) VALUES(@responseId, @questionId, @value);", connection);
                cmd.Parameters.AddWithValue("responseId", responseId);
                cmd.Parameters.AddWithValue("questionId", key);
                cmd.Parameters.AddWithValue("value", answers[key]);

                cmd.ExecuteNonQuery();

            }
            connection.Close();
            return GetResponse((uint) command.LastInsertedId);
        }

        public IEnumerable<IResponse> GetAllResponses(uint healthCheckId)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = "SELECT * FROM `response` WHERE `health_check_id`=@healthCheckId;";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@healthCheckId", healthCheckId);

            MySqlDataReader reader = command.ExecuteReader();

            List<Response> responses = new List<Response>();

            while (reader.Read())
            {
                responses.Add(reader.GetResponse());
            }

            reader.Close();
            foreach (var response in responses)
            {
                response.Answers = GetAnwersByResponse(response);

            }
            connection.Close();
            return responses.AsReadOnly();
        }

        public IResponse GetResponse(uint id)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = "SELECT * FROM `response` WHERE `id`=@id;";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            Response response = reader.GetResponse();

            reader.Close();

            response.Answers = GetAnwersByResponse(response);
            connection.Close();
            return response;
        }

        private IEnumerable<IAnswer> GetAnwersByResponse(Response response)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = "SELECT * FROM `answer` WHERE `response_id`=@id;";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("id", response.Id);

            MySqlDataReader reader = command.ExecuteReader();

            List<Answer> answers = new List<Answer>();
            while (reader.Read())
                answers.Add(reader.GetAnswer());
            reader.Close();
            answers.ForEach(a => a.Response = response);
            connection.Close();
            return answers.AsReadOnly();
        }
    }
}
