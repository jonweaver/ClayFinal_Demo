using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupDemo.Models
{
    public class GroupMember
    {
        public int GroupMemberId { get; set; }
        public string Name { get; set; }
        public virtual IList<Group> Groups { get; set; }
    }
}
