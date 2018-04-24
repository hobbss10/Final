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
    public partial class login : Form
    {
        string userId { get; set; }

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Login()
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

            string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Pass";
            MySqlCommand command = new MySqlCommand(query, dbConnect);
            command.Parameters.AddWithValue("@Email", tb_email.Text);
            command.Parameters.AddWithValue("@Pass", tb_pass.Text);

            int userExist = Convert.ToInt32(command.ExecuteScalar());

            if (userExist > 0)
            {
                //username exists
                if (tb_email.Text != "" && tb_pass.Text != "")
                {
                    this.userId = findUserID();
                    ViewEvents viewEvents = new ViewEvents(userId);
                    viewEvents.Show();
                }
                else
                {
                    MessageBox.Show("Please enter both email and password.", "Empty Fields");
                }
            }
            else
            {
                //username doesn't exist
                MessageBox.Show("Username or password is invalid", "Invalid Account");
            }

            dbConnect.Close();
        }

        private String findUserID()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = password; database = FontbonneDay; SslMode=none";
            MySqlConnection dbConnect = new MySqlConnection(connectionString);
            string ID = "";

            try
            {
                dbConnect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The connection failed!", "Connection Failed");
                DumpException(ex);
            }

            string query = "SELECT userID FROM users WHERE email = @Email";
            MySqlCommand command = new MySqlCommand(query, dbConnect);
            command.Parameters.AddWithValue("@Email", tb_email.Text);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string userID = reader["userID"].ToString();
                ID = userID;
            }

            reader.Close();
            dbConnect.Close();

            return ID;
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
