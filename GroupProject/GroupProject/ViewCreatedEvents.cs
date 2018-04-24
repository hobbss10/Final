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
    public partial class ViewCreatedEvents : Form
    {
        string userId;
        public ViewCreatedEvents()
        {
            InitializeComponent();
        }
        public ViewCreatedEvents(string id)
        {
            InitializeComponent();
            userId = id;
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
