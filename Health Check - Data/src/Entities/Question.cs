using HetBetereGroepje.HealthCheck.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data.Entities
{
    internal class Question : IQuestion
    {
        public uint ID { get; set; }

        public uint TemplateID { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public Question(uint id, uint teplateId, string header, string description)
        {
            ID = id;
            TemplateID = teplateId;
            Header = header;
            Description = description;
        }
    }

    internal static partial class ReaderExtensions
    {
        public static Question GetQuestion(this MySqlDataReader reader)
        {
            uint id = reader.GetUInt32("id");
            uint templateId = reader.GetUInt32("template_id");
            string header = reader.GetString("header");
            string description = reader.GetString("description");

            return new Question(id, templateId, header, description);
        }
    }
}
