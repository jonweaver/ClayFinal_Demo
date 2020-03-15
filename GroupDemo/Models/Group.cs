using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupDemo.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int GroupAdmin { get; set; }
        public virtual IList<GroupMember> GroupMembers { get; set; }
        public virtual IList<Event> Events { get; set; }
    }
}
