using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class Event
    {

        public int EventID { get; set; }
        public int Event_CreatorID { get; set; }
        public string EventName { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        public Event(int ID, int creatorID, string name, string time, string date, string desc)
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
