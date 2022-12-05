using HetBetereGroepje.HealthCheck.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data.Entities
{
    internal class HealthCheck : IHealthCheck
    {
        public uint ID { get; set; }
        public string Hash { get; set; }
        public uint TemplateID { get; set; }
        public uint OwnerID { get; set; }
        public string Name { get; set; }
        public HealthCheck(uint id, uint ownerId, uint templateId, string hash, string name)
        {
            ID = id;
            Hash = hash;
            TemplateID = templateId;
            OwnerID = ownerId;
            Name = name;
        }
    }

    internal static partial class ReaderExtensions
    {

        public static HealthCheck GetHealthCheck(this MySqlDataReader reader)
        {
            uint id = reader.GetUInt32("id");
            string hash = reader.GetString("hash");
            uint ownerId = reader.GetUInt32("owner_id");
            uint templateId = reader.GetUInt32("template_id");
            string name = reader.GetString("name");

            return new HealthCheck(id, ownerId, templateId, hash, name);
        }
    }
}
