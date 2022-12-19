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
    public class HealthCheckDataService : IHealthCheckDataService
    {
        [ServiceFactory]
        private static IHealthCheckDataService CreateService()
        {
            return new HealthCheckDataService();
        }


        private MySqlConnection connection;

        private HealthCheckDataService()
        {
            connection = DatabaseConnectionFactory.CreateConnection();
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }


        public IHealthCheck CreateHealthCheck(string tenantId, uint templateId, string hash, string name)
        {
            string query = @"INSERT INTO `health_check`(`tenant_id`,`template_id`, `hash`, `name`) VALUES
(@tenantId, @templateId, @hash, @name);";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("tenantId", tenantId);
            command.Parameters.AddWithValue("templateId", templateId);
            command.Parameters.AddWithValue("hash", hash);
            command.Parameters.AddWithValue("name", name);

            command.ExecuteNonQuery();

            return GetHealthCheck((uint)command.LastInsertedId);
        }

        public IHealthCheck GetHealthCheck(uint id)
        {
            string query = "SELECT * FROM `health_check` WHERE `id`=@id;";


            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                return null;
            }

            Entities.HealthCheck healthCheck = reader.GetHealthCheck();

            reader.Close();

            return healthCheck;
        }
        public IHealthCheck GetHealthCheck(string hash)
        {
            string query = "SELECT * FROM `health_check` WHERE `hash`=@hash;";


            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("hash", hash);

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                return null;
            }

            Entities.HealthCheck healthCheck = reader.GetHealthCheck();

            reader.Close();

            return healthCheck;
        }

        public IEnumerable<IHealthCheck> GetHealthChecksByTenant(string tenantId)
        {
            string query = "SELECT * FROM `health_check` WHERE `tenant_id`=@tenantId;";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("tenantId", tenantId);

            MySqlDataReader reader = command.ExecuteReader();

            List<IHealthCheck> healthChecks = new List<IHealthCheck>();

            while(reader.Read())
                healthChecks.Add(reader.GetHealthCheck());

            reader.Close();

            return healthChecks.AsReadOnly();
        }

    }
}
