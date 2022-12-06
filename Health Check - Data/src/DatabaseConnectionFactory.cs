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
            //TODO: Should read this from a file
            string host = "localhost";
            string username = "rhc_admin";
            string password = "r00t";
            string database = "rockstars_health_check";

            //host = "lauren-healthcheck.db.transip.me";
            //username = "lauren_hcadmin";
            //password = "r00tpass";
            //database = "lauren_healthcheck";
            string cs = $"server={host};userid={username};password={password};database={database}";


            return "Server=studmysql01.fhict.local;Uid=dbi469729;Database=dbi469729;Pwd=test";
            return cs;
        }
    }
}
