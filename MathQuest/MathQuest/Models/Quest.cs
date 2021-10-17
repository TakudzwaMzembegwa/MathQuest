using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathQ.Models
{
    public class Quest
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int questScore { get; set; }
        public String questDate { get; set; }
        public String questDuration { get; set; }
    }
}
