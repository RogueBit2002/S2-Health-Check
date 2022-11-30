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
            connection = DatabaseConnectionFactory.CreateConnection();
        }


        public ITemplate CreateTemplate(string name)
        {
            string query = @"INSERT INTO `template`(`name`) VALUES (@name);";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("name", name);

            command.ExecuteNonQuery();

            return GetTemplate((uint)command.LastInsertedId);
        }

        public ITemplate GetTemplate(uint id)
        {
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

            return template;
        }
    }
}
