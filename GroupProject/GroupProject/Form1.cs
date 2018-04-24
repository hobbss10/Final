using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class Form1 : Form
    {
        string userId;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Sign up";
            checkBox1.Checked = true;
        }


        private void Signup_Click(object sender, EventArgs e)
        {

            
            if((tb_fname.Text == "" || tb_lname.Text == "" || tb_email.Text == "" || tb_password.Text == "" || comboBox1.Text == "") || (checkBox1.Checked != true && checkBox2.Checked != true && checkBox3.Checked != true))
            {
                    MessageBox.Show("Pleae fill all fields.", "Empty Fields");
            }
            else
            {
                ViewEvents viewEvents = new ViewEvents(userId);
                viewEvents.Show();
            }
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
    }
}
