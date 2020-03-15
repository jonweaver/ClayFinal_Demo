using System;
using System.Linq;

namespace GroupDemo.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int EventAdmin { get; set; }
        public Group Group { get; set; }
    }
}
