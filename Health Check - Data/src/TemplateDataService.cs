using HetBetereGroepje.HealthCheck.Data.Entities;
using HetBetereGroepje.HealthCheck.Domain;
using HetBetereGroepje.HealthCheck.Factory;
using HetBetereGroepje.HealthCheck.IData;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data
{
    internal class TemplateDataService : ITemplateDataService
    {
        [ServiceFactory]
        private static ITemplateDataService CreateService()
        {
            return new TemplateDataService();
        }

        private MySqlConnection connection;
        public TemplateDataService()
        {
            //connection = DatabaseConnectionFactory.CreateConnection();
        }

        public void Dispose()
        {
            //connection.Close();
            //connection.Dispose();
        }

        public ITemplate CreateTemplate(string name)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = @"INSERT INTO `template`(`name`) VALUES (@name);";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("name", name);

            command.ExecuteNonQuery();
            connection.Close();
            return GetTemplate((uint)command.LastInsertedId);
        }

        public ITemplate GetTemplate(uint id)
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = "SELECT * FROM `template` WHERE `id`=@id;";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                return null;
            }

            Template template = reader.GetTemplate();

            reader.Close();
            connection.Close();
            return template;
        }

        public IEnumerable<ITemplate> GetTemplates()
        {
            MySqlConnection connection = DatabaseConnectionFactory.CreateConnection();

            string query = "SELECT * FROM `template`;";

            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            List<ITemplate> templates = new List<ITemplate>();

            while (reader.Read())
                templates.Add(reader.GetTemplate());

            reader.Close();
            connection.Close();
            return templates.AsReadOnly();
        }
    }
}
