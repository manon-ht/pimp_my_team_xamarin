using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PimpMyTeam
{
    public class MemberTeam
    {
        [ForeignKey(typeof(Member))]
        public int MemberId { get; set; }

        [ForeignKey(typeof(Team))]
        public int TeamId { get; set; }
    }
}
