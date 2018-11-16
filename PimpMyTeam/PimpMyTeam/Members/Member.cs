using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PimpMyTeam
{
    [Table("Member")]
    public class Member
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [ManyToMany(typeof(MemberTeam), "MemberId", "Members", CascadeOperations = CascadeOperation.All)]
        public List<Team> Teams { get; set; }

        public string Name
        {
            get { return FirstName + ' ' + LastName; }
        }
    }
}
