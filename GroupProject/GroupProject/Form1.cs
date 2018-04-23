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
        public Form1()
        {
            InitializeComponent();
            this.Text = "Sign up";
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            //login after signup
            login login = new login();
            login.Show();
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
    }
}
