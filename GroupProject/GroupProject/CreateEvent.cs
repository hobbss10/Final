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
    public partial class CreateEvent : Form
    {
        string userId { get; set; }

        public CreateEvent()
        {
            InitializeComponent();
        }
        public CreateEvent(string id)
        {
            InitializeComponent();
            this.userId = id;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_eventName.Text == "" || tb_date.Text == "" || tb_desc.Text == "")
            {
                MessageBox.Show("Please enter data in all fields", "Empty Fields");
            }
            else
            {
                CheckForUserCreatedEvents();
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_10.Checked == true)
            {
                rb_11.Checked = false;
                rb_12.Checked = false;
                rb_1.Checked = false;
                rb_2.Checked = false;
                rb_3.Checked = false;
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_11.Checked == true)
            {
                rb_10.Checked = false;
                rb_12.Checked = false;
                rb_1.Checked = false;
                rb_2.Checked = false;
                rb_3.Checked = false;
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_12.Checked == true)
            {
                rb_10.Checked = false;
                rb_11.Checked = false;
                rb_1.Checked = false;
                rb_2.Checked = false;
                rb_3.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_1.Checked == true)
            {
                rb_10.Checked = false;
                rb_11.Checked = false;
                rb_12.Checked = false;
                rb_2.Checked = false;
                rb_3.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_2.Checked == true)
            {
                rb_10.Checked = false;
                rb_11.Checked = false;
                rb_12.Checked = false;
                rb_1.Checked = false;
                rb_3.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_3.Checked == true)
            {
                rb_10.Checked = false;
                rb_11.Checked = false;
                rb_12.Checked = false;
                rb_1.Checked = false;
                rb_2.Checked = false;
            }
        }

        private void CheckForUserCreatedEvents()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = password; database = FontbonneDay; SslMode=none";
            MySqlConnection dbConnect = new MySqlConnection(connectionString);

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

            int userExist = Convert.ToInt32(command.ExecuteScalar());

            if (userExist > 0)
            {
                //username exists
                MessageBox.Show("User already has created an event!", "Already Created an Event!");
            }
            else
            {
                //user hasn't created an event
                addEvent();
            }

            dbConnect.Close();

        }

        private void addEvent()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = password; database = FontbonneDay; SslMode=none";
            MySqlConnection dbConnect = new MySqlConnection(connectionString);

            string timeBox;
            if(rb_10.Checked == true)
            {
                timeBox = "10:00 AM";
            }else if(rb_11.Checked == true)
            {
                timeBox = "11:00 AM";
            }else if(rb_12.Checked == true)
            {
                timeBox = "12:00 PM";
            }else if(rb_1.Checked == true)
            {
                timeBox = "1:00 PM";
            }else if(rb_2.Checked == true)
            {
                timeBox = "2:00 PM";
            }
            else
            {
                timeBox = "3:00 PM";
            }

            try
            {
                dbConnect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The connection failed!", "Connection Failed");
                DumpException(ex);
            }

            string query = "Insert into events (event_CreatorID, eventName, time, date, description) values (@EventCreator, @Name, @Time, @Date, @Description)";

            MySqlCommand command = new MySqlCommand(query, dbConnect);

            command.Parameters.AddWithValue("@EventCreator", this.userId);
            command.Parameters.AddWithValue("@Name", tb_eventName.Text);
            command.Parameters.AddWithValue("@Time", timeBox);
            command.Parameters.AddWithValue("@Date", tb_date.Text);
            command.Parameters.AddWithValue("@Description", tb_desc.Text);

            command.ExecuteNonQuery();

            query = "SELECT eventID FROM events WHERE eventName = @EventName";
            MySqlCommand comm = new MySqlCommand(query, dbConnect);
            comm.Parameters.AddWithValue("@EventName", tb_eventName.Text);

            MySqlDataReader reader = comm.ExecuteReader();
            string eID = "";
            while (reader.Read())
            {
                string eventID = reader["eventID"].ToString();
                eID = eventID;
            }
            reader.Close();

            query = "Insert into usercreatedevents (eventID, userID) values (@EventID, @UserID)";

            MySqlCommand c = new MySqlCommand(query, dbConnect);

            c.Parameters.AddWithValue("@EventID", eID);
            c.Parameters.AddWithValue("@UserID", this.userId);

            c.ExecuteNonQuery();

            query = "INSERT into userevents (eventID, userID) VALUES (@EventID, @UserID)";

            MySqlCommand addToUsers = new MySqlCommand(query, dbConnect);

            addToUsers.Parameters.AddWithValue("@EventID", eID);
            addToUsers.Parameters.AddWithValue("@UserID", this.userId);

            addToUsers.ExecuteNonQuery();

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
    }
}
