using HetBetereGroepje.HealthCheck.Domain.Low;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data.Entities
{
    internal class Manager : IManagerLow
    {
        public uint ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Manager(uint id, string email, string password)
        {
            ID = id;
            Email = email;
            Password = password;
        }
    }

    internal static partial class ReaderExtensions
    {

        public static Manager GetManager(this MySqlDataReader reader)
        {
            uint id = reader.GetUInt32("id");
            string email = reader.GetString("email");
            string password = reader.GetString("password");
            
            return new Manager(id, email, password);
        }
    }
}
