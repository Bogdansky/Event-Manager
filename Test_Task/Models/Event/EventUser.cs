using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Task.Models.Event
{
    [Serializable]
    public class EventUser
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

        public string UserId { get; set; }
    }
}