using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PimpMyTeam
{
    [Table("Team")]
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        [ManyToMany(typeof(MemberTeam), "TeamId", "Teams", ReadOnly = true)]
        public List<Member> Members { get; set; }
    }
}
