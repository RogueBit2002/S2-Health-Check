using HetBetereGroepje.HealthCheck.Domain.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HetBetereGroepje.HealthCheck.Data.Entities
{
    public class Question : IQuestion
    {
        public uint ID { get; set; }

        public string Text { get; set; }

        public Question(uint id, string text)
        {
            ID = id;
            Text = text;
        }
    }
}
