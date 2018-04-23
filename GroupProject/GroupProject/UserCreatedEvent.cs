using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class UserCreatedEvent
    {

        public int UserID { get; set; }
        public int EventID { get; set; }

        public UserCreatedEvent(int userID, int eventID)
        {
            UserID = userID;
            EventID = eventID;
        }
    }
}
