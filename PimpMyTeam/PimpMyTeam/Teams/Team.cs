using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PimpMyTeam
{
    [Table("Team")]
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
