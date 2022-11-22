using HetBetereGroepje.HealthCheck.Data.Entities;
using HetBetereGroepje.HealthCheck.Domain.High;
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


        public IHealthCheck CreateHealthCheck(uint managerId, string hash, string name)
        {
            try
            {
                string query = @"INSERT INTO `health_check`(`owner_id`, `hash`, `name`) VALUES
    (@managerId, @hash, @name);";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("managerId", managerId);
                command.Parameters.AddWithValue("hash", hash);
                command.Parameters.AddWithValue("name", name);

                command.ExecuteNonQuery();

                return GetHealthCheck((uint)command.LastInsertedId);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
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

        public IEnumerable<IHealthCheck> GetHealthChecksByManager(uint managerId)
        {
            string query = "SELECT * FROM `health_check` WHERE `owner_id`=@managerId;";


            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("managerId", managerId);

            MySqlDataReader reader = command.ExecuteReader();

            List<IHealthCheck> healthChecks = new List<IHealthCheck>();

            while(reader.Read())
                healthChecks.Add(reader.GetHealthCheck());

            reader.Close();

            return healthChecks.AsReadOnly();
        }

    }
}
