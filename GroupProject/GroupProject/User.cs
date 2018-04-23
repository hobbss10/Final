using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string DepartmentName { get; set; }

        public User(int ID, string fName, string lName, string mail, string pass, string stat, string dept)
        {
            UserID = ID;
            FirstName = fName;
            LastName = lName;
            Email = mail;
            Password = pass;
            Status = stat;
            DepartmentName = dept;
        }
    }
}
