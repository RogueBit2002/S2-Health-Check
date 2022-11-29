using HetBetereGroepje.HealthCheck.Domain.Low;
using HetBetereGroepje.HealthCheck.IData;
using HetBetereGroepje.HealthCheck.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace HetBetereGroepje.HealthCheck.Data
{
    public class ManagerDataService : IManagerDataService
    {
        private MySqlConnection connection;

        private ManagerDataService()
        {
            connection = DatabaseConnectionFactory.CreateConnection();
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }

        public IManagerLow GetManager(uint id)
        {
            string query = "SELECT * FROM `manager` WHERE `id`=@id;";

            
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader reader = command.ExecuteReader();

            if(!reader.Read())
            {
                reader.Close();
                return null;
            }

            Manager manager = reader.GetManager();

            
            reader.Close();

            return manager;
        }

        public IManagerLow GetManager(string email)
        {
            string query = "SELECT * FROM `manager` WHERE `email`=@email;";


            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("email", email);

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                return null;
            }

            Manager manager = reader.GetManager();

            reader.Close();

            return manager;
        }
    }
}
