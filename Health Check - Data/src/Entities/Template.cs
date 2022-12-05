using HetBetereGroepje.HealthCheck.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data.Entities
{
    internal class Template : ITemplate
    {
        public uint ID { get; set; }

        public string Name { get; set; }

        public IEnumerable<uint> QuestionIDs { get; set; }

        public Template(uint id, string name)
        {
            ID = id;
            Name = name;
        }
    }

    internal static partial class ReaderExtensions
    {
        public static Template GetTemplate(this MySqlDataReader reader)
        {
            uint id = reader.GetUInt32("id");
            string name = reader.GetString("name");

            return new Template(id, name);
        }
    }
}
