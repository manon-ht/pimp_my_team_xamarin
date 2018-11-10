using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PimpMyTeam
{
    [Table("Member")]
    public class Member
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Name
        {
            get { return FirstName + ' ' + LastName; }
        }
    }
}
