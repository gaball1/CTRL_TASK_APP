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
using static c_project.SignUp;
using c_project.database;
using System.IO;

namespace c_project
{
    public partial class Setting : Form
    {
        public string imgPath = "";
        public Setting()
        {
            InitializeComponent();
            textBox1.Text = currentUser.u_name;
            textBox2.Text = currentUser.u_email; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data db = new Data();
           if(!string.IsNullOrEmpty(textBox1.Text))
            {
                currentUser.u_name = textBox1.Text;
            }
            if(!string.IsNullOrEmpty(textBox2.Text))
            { currentUser.u_email = textBox2.Text; }
            currentUser.u_password = textBox3.Text;
            if (textBox2.Text!=currentUser.u_email)
            {
                MessageBox.Show("There is a user with that email, please try a different one");
            }else
            {
                currentUser.UpdateUserData(currentUser);

                db.SaveChanges();
                if (imgPath != "")
                {
                   
                    string path = Environment.CurrentDirectory + "\\images\\users\\" + currentUser.u_id + ".jpg";
                    File.Copy(imgPath, path);
                    currentUser.img = path;

                }
                db.SaveChanges();
                MessageBox.Show("The user has been updated");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DashBoard d = new DashBoard();
            d.Show();
            this.Close();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();

            string imagePath = currentUser.img;
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
                MessageBox.Show("Image deleted successfully.");
            }
            else
            {
                MessageBox.Show("Image does not exist.");
            }

            if (img.ShowDialog() == DialogResult.OK)
            {
                imgPath = "";
                imgPath = img.FileName;
                pictureBox1.ImageLocation = img.FileName;
            }
        }
    }
}
