using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using c_project.database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace c_project
{
    public partial class SignUp : Form
    {
        public static userdata currentUser;
        public static project currentProject;
        public static task currentTask;
        public Point mouseLocation;


        public string imgPath="";
        public SignUp()
        {
            InitializeComponent();
            this.ActiveControl = usernametextbox;
            usernametextbox.Focus();
            this.KeyPreview = true;
        }
       
        private void SignUp_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Email_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Data db = new Data();
            if (c_pass.Text == Pass.Text && !string.IsNullOrWhiteSpace(usernametextbox.Text) && !string.IsNullOrWhiteSpace(email0.Text) && !string.IsNullOrWhiteSpace(Pass.Text))
            {
                userdata u1 = new userdata()
                {
                    u_name = usernametextbox.Text,
                    u_email = email0.Text,
                    u_password = Pass.Text
                };

                bool isvalide = true, isvalidn = true, isvalidpass = true, isvalid = true;
                //  bool isvalidname=true ;
                // adduser au1 = new adduser();
                //calling to ensure name
                u1.validname(u1.u_name, ref isvalidn);
                /*
                       if (isvalid)
                           MessageBox.Show("correct");
                       else
                           MessageBox.Show("not correct");*/
                //calling to ensure email
                u1.validemail(u1.u_email, ref isvalide);
                /* if(isvalid)
                     MessageBox.Show("correct");
                 else
                     MessageBox.Show("not correct");*/
                //calling to ensure pass
                u1.vaildpass(u1.u_password, ref isvalidpass);
                /* if (isvalid)
                     MessageBox.Show("correct");
                 else
                     MessageBox.Show("not correct");*/
                u1.adduser(ref isvalidpass, ref isvalidn, ref isvalide, ref isvalid);
                //  if (!string.IsNullOrWhiteSpace(u1.u_name) && !string.IsNullOrWhiteSpace(u1.u_password) && !string.IsNullOrWhiteSpace(u1.u_email))
                //{


                if (isvalid)
                {
                    currentUser = u1.isFoundUser(u1);
                    userdata u = new userdata();
                    u = u1.searchByEmail(u1);
                    if (currentUser != null || u != null)
                    {
                        MessageBox.Show("User already Exists, please sign up");
                        currentUser = null;
                    }
                    else
                    {
                        // u1.img = imgPath;
                        u1.u_password = hash(u1.u_password);
                        db.userdata.Add(u1);
                        db.SaveChanges();
                        if (imgPath != "")
                        {
                            string path = Environment.CurrentDirectory + "\\images\\users\\" + u1.u_id + ".jpg";
                            File.Copy(imgPath, path);
                            u1.img = path;

                        }

                        db.SaveChanges();
                        MessageBox.Show("Successful singup");
                        currentUser = u1;
                        project p = new project();
                        p.p_name = "Default";
                        p.u_id = currentUser.u_id;
                        //p.p_done = false;
                        p.number_of_tasks = 0;
                        p.addProject(p);
                        db.SaveChanges();
                        currentProject = p;
                        //MessageBox.Show("default has been created");
                        Log_in l = new Log_in();
                        l.Show();
                        this.Close();
                    }
                }
                else if (isvalide && isvalidn)
                    MessageBox.Show("too short password");
                else if (isvalide && isvalidpass)
                    MessageBox.Show("name that you was entered not vaild, Please enter olny letters");
                else if (isvalidpass && isvalidn)
                    MessageBox.Show("not vaild email");
                else if (isvalide)
                    MessageBox.Show("not vaild name and password");
                else if (isvalidn)
                    MessageBox.Show("not vaild email and password");
                else if (isvalidpass)
                    MessageBox.Show("not vaild name and email");
                else
                    MessageBox.Show("not vaild input");


                // }
                /* else
                 {
                     if(string.IsNullOrWhiteSpace(u1.u_name)&& string.IsNullOrWhiteSpace(u1.u_password))
                         MessageBox.Show("please enter your name and ")
                 }*/

            }
            else if(string.IsNullOrWhiteSpace(usernametextbox.Text)||string.IsNullOrWhiteSpace(Pass.Text)||string.IsNullOrWhiteSpace(email0.Text)|| string.IsNullOrWhiteSpace(c_pass.Text))
            {
                MessageBox.Show("please complete your data");
            }
            else
            {
                MessageBox.Show("please check your password");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();

            if (img.ShowDialog() == DialogResult.OK)
            {
                imgPath = img.FileName;
                pictureBox1.ImageLocation = img.FileName;
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }


        private void button4_Click_2(object sender, EventArgs e)
        {
         
        }

        private void SignUp_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);

        }

        private void SignUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void usernametxtbox_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                email0.Focus();
            }
        }

        private void email_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Pass.Focus();
            }
        }
        private void pass_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                c_pass.Focus();
            }
        }
        private void c_passkeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.Focus();
            }
        }

       


        public string hash(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Log_in l = new Log_in();
            l.Show();
            this.Close();
        }

        private void Showpassword_Click(object sender, EventArgs e)
        {
            if (Pass.PasswordChar == '*')
            {
                HidePassword.BringToFront();
                Pass.PasswordChar = '\0';
            }
        }

        private void HidePassword_Click(object sender, EventArgs e)
        {
            if (Pass.PasswordChar == '\0')
            {
                Showpassword.BringToFront();
                Pass.PasswordChar = '*';
            }
        }

        private void showpass_Click(object sender, EventArgs e)
        {
            if (c_pass.PasswordChar == '*')
            {
                hidepass.BringToFront();
                c_pass.PasswordChar = '\0';
            }
        }

        private void hidepass_Click(object sender, EventArgs e)
        {
            if (c_pass.PasswordChar == '\0')
            {
                showpass.BringToFront();
                c_pass.PasswordChar = '*';
            }
        }
    }

}
