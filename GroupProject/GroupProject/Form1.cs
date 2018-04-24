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
    public partial class Form1 : Form
    {
        string userId { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.Text = "Sign up";
            checkBox1.Checked = true;
        }


        private void Signup_Click(object sender, EventArgs e)
        {

            addUser();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //department choices
            comboBox1.Items.Add("Department of Behavioral Sciences");
            comboBox1.Items.Add("Department of Biological and Physical Sciences");
            comboBox1.Items.Add("Department of Business");
            comboBox1.Items.Add("Department of Communication Disorders and Deaf Education");
            comboBox1.Items.Add("Department of Education and Special Education");
            comboBox1.Items.Add("Department of English and Communication");
            comboBox1.Items.Add("Department of Family and Consumer Sciences");
            comboBox1.Items.Add("Department of Fashion Merchandising");
            comboBox1.Items.Add("Department of Fine Arts");
            comboBox1.Items.Add("Department of History, Philosophy and Religion");
            comboBox1.Items.Add("Department of Interdisciplinary Studies");
            comboBox1.Items.Add("Department of Mathematics and Computer Science");
            comboBox1.Items.Add("Department of Social Work");
            comboBox1.Items.Add("Other");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //status choice
            comboBox1.Items.Add("Faculty");
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Staff");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
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

        private void addUser()
        {
            if ((tb_fname.Text == "" || tb_lname.Text == "" || tb_email.Text == "" || tb_password.Text == "" || comboBox1.Text == "") || (checkBox1.Checked != true && checkBox2.Checked != true && checkBox3.Checked != true))
            {
                MessageBox.Show("Pleae fill all fields.", "Empty Fields");
            }
            else
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

                string stat;
                if (checkBox1.Checked == true)
                {
                    stat = checkBox1.Text;
                }
                else if (checkBox2.Checked == true)
                {
                    stat = checkBox2.Text;
                }
                else
                {
                    stat = checkBox3.Text;
                }

                string query = "Insert into users (firstName, lastName, email, password, status, departmentName) values (@fName, @lName, @Email, @Password, @Status, @Department)";

                MySqlCommand command = new MySqlCommand(query, dbConnect);

                command.Parameters.AddWithValue("@fName", tb_fname.Text);
                command.Parameters.AddWithValue("@lName", tb_lname.Text);
                command.Parameters.AddWithValue("@Email", tb_email.Text);
                command.Parameters.AddWithValue("@Password", tb_password.Text);
                command.Parameters.AddWithValue("@Status", stat);
                command.Parameters.AddWithValue("Department", comboBox1.Text);

                command.ExecuteNonQuery();

                dbConnect.Close();

                this.userId = findUserID();

                ViewEvents viewEvents = new ViewEvents(userId);
                viewEvents.Show();
            }
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

            string query = "SELECT userID FROM user WHERE email = @Email";
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
    }
}
