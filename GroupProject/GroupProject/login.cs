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
    public partial class login : Form
    {
        string userId = "";
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != "" && textBox4.Text != "")
            {
                ViewEvents viewEvents = new ViewEvents(userId);
                viewEvents.Show();
            }
            else
            {
                MessageBox.Show("Please enter both email and password.", "Empty Fields");
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            
        }
    }
}
