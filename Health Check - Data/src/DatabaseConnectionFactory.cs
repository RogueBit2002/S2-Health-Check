using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data
{
    internal static class DatabaseConnectionFactory
    {

        public static MySqlConnection CreateConnection()
        {
            MySqlConnection connection = new MySqlConnection(GetConnectionString());
            connection.Open();

            return connection;
        }

        private static string GetConnectionString()
        {
            return "Server=studmysql01.fhict.local;Uid=dbi469729;Database=dbi469729;Pwd=test";
        }
    }
}
