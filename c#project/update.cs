using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using c_project.database;
using static c_project.SignUp;




namespace c_project
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
            textBox1.Text = currentTask.t_name;
            textBox2.Text = currentTask.content;
            dateTimePicker1.Value = currentTask.date_time_finish.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data db = new Data();
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                currentTask.t_name = textBox1.Text;

            }
            
            if(!string.IsNullOrEmpty(textBox2.Text))
            {
                currentTask.content = textBox2.Text;

            }
            currentTask.date_time_finish = dateTimePicker1.Value;
            currentTask.updateTask(currentTask);
            db.SaveChanges();
            MessageBox.Show("task has been updated");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaskPage  pg = new TaskPage();
            pg.Show();  
            this.Close();    
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaskPage tp = new TaskPage();
            tp.Show();
            this.Close();
        }

        private void DedLine_Click(object sender, EventArgs e)
        {

        }

        private void Task1_Click(object sender, EventArgs e)
        {

        }
    }
}
