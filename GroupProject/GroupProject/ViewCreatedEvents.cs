using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GroupProject
{
    public partial class ViewCreatedEvents : Form
    {
        string userId { get; set; }

        public ViewCreatedEvents()
        {
            InitializeComponent();
        }
        public ViewCreatedEvents(string id)
        {
            InitializeComponent();
            userId = id;

            ShowUserEvents();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }

        public void Header()
        {
            textBoxEvents.Text += "Date\tTime\tEvent Name\t\tDescription\r\n";
        }

        private void ShowUserEvents()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = password; database = FontbonneDay; SslMode=none";
            MySqlConnection dbConnect = new MySqlConnection(connectionString);

            List<string> list = new List<string>();
            List<Event> eventList = new List<Event>();

            try
            {
                dbConnect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The connection failed!", "Connection Failed");
                DumpException(ex);
            }

            string query = "SELECT eventID FROM userevents WHERE userID = @UserID";
            MySqlCommand command = new MySqlCommand(query, dbConnect);
            command.Parameters.AddWithValue("@UserID", this.userId);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string eventID = reader["eventID"].ToString();
                list.Add(eventID);
            }
            reader.Close();

            foreach (String e in list)
            {
                query = "SELECT * FROM events WHERE eventID = @EventID";
                MySqlCommand comm = new MySqlCommand(query, dbConnect);
                comm.Parameters.AddWithValue("@EventID", e);

                MySqlDataReader reader2 = comm.ExecuteReader();
                while (reader2.Read())
                {
                    string eventCreator = reader2["event_CreatorID"].ToString();
                    string eventName = reader2["eventName"].ToString();
                    string time = reader2["time"].ToString();
                    string date = reader2["date"].ToString();
                    string desc = reader2["description"].ToString();

                    Event ev = new Event(e, eventCreator, eventName, time, date, desc);
                    eventList.Add(ev);
                }
                reader2.Close();
            }

            Header();
            foreach (Event ev in eventList)
            {
                textBoxEvents.Text += ev.Date + "\t" + ev.Time + "\t" + ev.EventName + "\t" + ev.Description + "\r\n";
            }

            reader.Close();
            dbConnect.Close();
        }

        private void DeleteEvent()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = password; database = FontbonneDay; SslMode=none";
            MySqlConnection dbConnect = new MySqlConnection(connectionString);
            string event_ID = "";

            try
            {
                dbConnect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The connection failed!", "Connection Failed");
                DumpException(ex);
            }

            string query = "SELECT COUNT(*) FROM usercreatedevents WHERE userID = @UserID";

            MySqlCommand command = new MySqlCommand(query, dbConnect);

            command.Parameters.AddWithValue("@UserID", this.userId);

            int userExist = (int)command.ExecuteScalar();

            if (userExist > 0)
            {

                query = "SELECT eventID FROM usercreatedevents WHERE userID = @UserID";
                MySqlCommand findEventID = new MySqlCommand(query, dbConnect);
                findEventID.Parameters.AddWithValue("@UserID", this.userId);
                MySqlDataReader reader = findEventID.ExecuteReader();
                while (reader.Read())
                {
                    string eventID = reader["eventID"].ToString();
                    event_ID = eventID;
                }
                reader.Close();

                query = "DELETE FROM usercreatedevents WHERE userID = @UserID";
                MySqlCommand comm = new MySqlCommand(query, dbConnect);
                comm.Parameters.AddWithValue("@UserID", this.userId);
                comm.ExecuteNonQuery();

                query = "DELETE FROM events WHERE event_CreatorID = @UserID";
                MySqlCommand com = new MySqlCommand(query, dbConnect);
                com.Parameters.AddWithValue("@UserID", this.userId);
                com.ExecuteNonQuery();

                query = "DELETE FROM userevents WHERE eventID = @EventID";
                MySqlCommand deleteUserEvents = new MySqlCommand(query, dbConnect);
                deleteUserEvents.Parameters.AddWithValue("@EventID", event_ID);
                deleteUserEvents.ExecuteNonQuery();

                dbConnect.Close();
            }
            else
            {
                MessageBox.Show("No Events Owned by the User", "Deletion Error");
            }
        }

        /// <summary>
        /// A couple of exception handling/information gathering functions
        /// </summary>
        /// <param name="ex"></param>
        public static void DumpException(Exception ex)
        {
            Console.Write("--------- Outer Exception Data ---------");
            WriteExceptionInfo(ex);
            ex = ex.InnerException;
            if (null != ex)
            {
                Console.Write("--------- Inner Exception Data ---------");
                WriteExceptionInfo(ex.InnerException);
                ex = ex.InnerException;
            }
        }
        public static void WriteExceptionInfo(Exception ex)
        {
            Console.WriteLine("Message: {0}", ex.Message);
            Console.WriteLine("Exception Type: {0}", ex.GetType().FullName);
            Console.WriteLine("Source: {0}", ex.Source);
            Console.WriteLine("StrackTrace: {0}", ex.StackTrace);
            Console.WriteLine("TargetSite: {0}", ex.TargetSite);
        }
    }
}
