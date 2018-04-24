using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class Event
    {

        public string EventID { get; set; }
        public string Event_CreatorID { get; set; }
        public string EventName { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        public Event(string ID, string creatorID, string name, string time, string date, string desc)
        {
            EventID = ID;
            Event_CreatorID = creatorID;
            EventName = name;
            Time = time;
            Date = date;
            Description = desc;
        }
    }
}
