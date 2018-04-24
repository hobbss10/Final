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
    public partial class ViewEvents : Form
    {
        string userId;
        public ViewEvents()
        {
            InitializeComponent();
        }
        public ViewEvents(string id)
        {
            InitializeComponent();
            userId = id;
            button1.Enabled = false;
            button2.Enabled = false;
        }


        private void textBoxEvents_TextChanged(object sender, EventArgs e)
        {

        }

        private void dropDownEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dropDownEvents.Text != null)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eventName = dropDownEvents.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string eventName = dropDownEvents.Text;

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
    }
}
