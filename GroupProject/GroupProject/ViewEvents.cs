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
    public partial class ViewEvents : Form
    {
        string userId { get; set; }

        List<string> names = new List<string>();

        public ViewEvents()
        {
            InitializeComponent();
        }
        public ViewEvents(string id)
        {
            InitializeComponent();
            userId = id;
            b_join.Enabled = false;

            ShowAllEvents();
        }


        private void textBoxEvents_TextChanged(object sender, EventArgs e)
        {

        }

        private void dropDownEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dropDownEvents.Text != null)
            {
                b_join.Enabled = true;
            }
            else
            {
                b_join.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void createEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEvent createEvent = new CreateEvent(userId);
            createEvent.Show();
        }

        private void viewUserEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCreatedEvents viewCreatedEvents = new ViewCreatedEvents(userId);
            viewCreatedEvents.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowAllEvents()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = password; database = FontbonneDay; SslMode=none";
            MySqlConnection dbConnect = new MySqlConnection(connectionString);

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

            string query = "SELECT * FROM events";
            MySqlCommand command = new MySqlCommand(query, dbConnect);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string event_ID = reader["eventID"].ToString();
                string eventCreator = reader["event_CreatorID"].ToString();
                string eventName = reader["eventName"].ToString();
                string time = reader["time"].ToString();
                string date = reader["date"].ToString();
                string desc = reader["description"].ToString();

                Event ev = new Event(event_ID, eventCreator, eventName, time, date, desc);
                eventList.Add(ev);
            }

            header();
            foreach (Event e in eventList)
            {
                textBoxEvents.Text += e.Date + "\t" + e.Time + "\t" + e.EventName + "\t" + e.Description + "\r\n";
                names.Add(e.EventName);
            }
            dropDownEvents.DataSource = names;
        }

        public void header()
        {
            textBoxEvents.Text += "Date\tTime\tEvent Name\t\tDescription\r\n";
        }

        private void CheckIfJoinedEvent()
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

            string query = "SELECT COUNT(*) FROM userevents WHERE userID = @UserID";

            MySqlCommand command = new MySqlCommand(query, dbConnect);
            command.Parameters.AddWithValue("@UserID", this.userId);

            int userExist = Convert.ToInt32(command.ExecuteScalar());

            if (userExist > 0)
            {
                //username exists
                //so update entry with new eventID

                query = "SELECT eventID FROM userevents WHERE userID = @UserID";
                MySqlCommand comm = new MySqlCommand(query, dbConnect);
                comm.Parameters.AddWithValue("@UserID", this.userId);

                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string eID = reader["eventID"].ToString();
                    event_ID = eID;
                }

                string newEventID = "";
                query = "SELECT eventID FROM events WHERE eventName = @EventName";
                MySqlCommand findNewID = new MySqlCommand(query, dbConnect);
                findNewID.Parameters.AddWithValue("@EventName", textBoxEvents.Text);
                reader = findNewID.ExecuteReader();
                while (reader.Read())
                {
                    newEventID = reader["eventID"].ToString();
                }
                reader.Close();

                query = "UPDATE userevents SET eventID = " + newEventID + " WHERE userID = @UserID AND eventID = @EventID";
                MySqlCommand c = new MySqlCommand(query, dbConnect);
                c.Parameters.AddWithValue("@UserID", this.userId);
                c.Parameters.AddWithValue("@EventID", event_ID);
                c.ExecuteNonQuery();
            }
            else
            {
                //user doesn't exist in table
                joinEvent();
            }

            dbConnect.Close();
        }

        private void joinEvent()
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

            string query = "SELECT eventID FROM events where eventName = @Event";
            MySqlCommand command = new MySqlCommand(query, dbConnect);
            command.Parameters.AddWithValue("@Event", textBoxEvents.Text);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string eID = reader["eventID"].ToString();
                event_ID = eID;
            }

            query = "INSERT into userevents (eventID, userID) values (@EventID, @UserID)";

            MySqlCommand comm = new MySqlCommand(query, dbConnect);
            comm.Parameters.AddWithValue("@EventID", event_ID);
            comm.Parameters.AddWithValue("@UserID", this.userId);

            comm.ExecuteNonQuery();

            reader.Close();
            dbConnect.Close();
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

        private void ViewEvents_DoubleClick(object sender, EventArgs e)
        {
            ShowAllEvents();
        }
    }
}
