using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_project
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void Ctrltask_Click(object sender, EventArgs e)
        {

        }

        private void i_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Log_in login = new Log_in();
            login.Show();
            this.Hide();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp sign = new SignUp(); 
            sign.Show();
            this.Hide();
        }
    }
}
