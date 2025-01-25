using c_project.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Data.SqlClient;
using static c_project.SignUp;
using System.Text.RegularExpressions;
using static c_project.DashBoard;
namespace c_project
{
    public partial class Log_in : Form
    {
        Data obj = new Data();
        public Point mouseLocation;

        public Log_in()
        {
            InitializeComponent();
            this.ActiveControl = textUserName;
            textUserName.Focus();

            // Attach event handlers
            textUserName.KeyDown += textbox1_keydown;
            textPassword.KeyDown += textbox2_keydown;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Data c1 = new Data();
            totalTasks = 0;
            doneTasksForToday = 0;
            string userEmail = textUserName.Text, userPass = textPassword.Text;
            if (!string.IsNullOrWhiteSpace(userEmail) && !string.IsNullOrWhiteSpace(userPass))
            {
                userdata u1 = new userdata();
                project p = new project();
                p.p_name = "Default";
                u1.u_email = userEmail;
                u1.u_password = userPass;
                //  bool yy= VerifyPassword(userPass, u1.u_password);

                if (u1.isFoundUser(u1) != null)
                {
                    //  MessageBox.Show("user is here");
                    DashBoard d = new DashBoard();
                    currentUser = u1.isFoundUser(u1);

                    currentProject = p.searchProject(p.p_name, currentUser.u_id);
                    d.Show();
                    this.Close();
                    var projects = c1.project.Where(a => a.u_id == currentUser.u_id);
                    foreach (project pr in projects)
                    {
                        totalTasks += (int)pr.number_of_tasks;
                        var done = c1.task.Where(a => a.p_id == pr.p_id && a.t_done == true);
                        doneTasksForToday += done.Count();
                    }
                }
                else
                {
                    MessageBox.Show("No user with that data. please try again or sign up");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(userEmail) && string.IsNullOrWhiteSpace(userPass))
                    MessageBox.Show("please enter your password and email");
                else if (string.IsNullOrWhiteSpace(userEmail))
                    MessageBox.Show("please enter your email");
                else if (string.IsNullOrWhiteSpace(userPass))
                    MessageBox.Show("please enter your password");
            }

        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp s = new SignUp();
            s.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textPassword.PasswordChar == '*') {
                button4.BringToFront();
                textPassword.PasswordChar = '\0';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textPassword.PasswordChar == '\0') { 
            button3.BringToFront(); 
             textPassword.PasswordChar = '*';
            }
        }

        private void Log_in_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Log_in_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void L(object sender, MouseEventArgs e)
        {

        }

        private void textbox1_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                textPassword.Focus();
            }
        }

        private void textUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox2_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                button1.PerformClick(); // Simulates a click on the login button
            }
        }

       

       


        //public bool VerifyPassword(string newPassword, string hashedPassword)
        //{
        //    Regex saltRegex = new Regex(@"^\$2[aby]\$\d{2}\$[./A-Za-z0-9]{53}$");

        //    if (saltRegex.IsMatch(hashedPassword))
        //    {
        //        // Proceed with verification
        //        bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(newPassword, hashedPassword);
        //        if (isPasswordCorrect)
        //        {
        //            MessageBox.Show("the password is correct");
        //        }
        //        else MessageBox.Show("the password is wrong");
        //    }
        //    else
        //    {
        //        MessageBox.Show("no passwoed");
        //        // Handle the case where the salt is not in the expected format
        //    }
        //    return BCrypt.Net.BCrypt.Verify(newPassword, hashedPassword);
        //}
    }
}
