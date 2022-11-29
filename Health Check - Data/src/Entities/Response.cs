using HetBetereGroepje.HealthCheck.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data.Entities
{
    public class Response : IResponse
    {
        public string Email { get; set; }

        public uint Id { get; set; }

        public uint HealthCheckId { get; set; }

        public IEnumerable<IAnswer> Answers { get; set; }

        public Response(uint id, string email, uint healthCheckId, IEnumerable<IAnswer> answers)
        {
            Email = email;
            Id = id;
            HealthCheckId = healthCheckId;
            Answers = answers;
        }
    }

    internal static partial class ReaderExtensions
    {
        public static Response GetResponse(this MySqlDataReader reader)
        {
            uint id = reader.GetUInt32("id");
            uint healthCheckId = reader.GetUInt32("health_check_id");
            string email = reader.GetString("email");


            return new Response(id, email, healthCheckId, null);
        }
    }
}
