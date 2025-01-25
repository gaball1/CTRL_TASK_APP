using c_project.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static c_project.SignUp;
using LiveCharts;
using static c_project.DashBoard;
using System.IO;

namespace c_project
{
    
    public partial class TaskPage : Form
    {
        public Point mouseLocation;

        
        bool deadLineClicked = false;
        public string imgPath = "";
        public TaskPage()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();
            this.KeyPreview = true;
            //project rr = r;
            //dataGridView1.DataSource = rr.ToString();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TaskPage_Load(object sender, EventArgs e)
        {
            Data db = new Data();
            bridge_task_userdata br = new bridge_task_userdata();
            int count = 0;
            List<task> tasks4 = db.task.Where(a => a.p_id == currentProject.p_id && a.t_status == 4 && a.t_done == false).ToList();
            foreach (task t in tasks4)
            {
                dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
            }
            List<task> tasks3 = db.task.Where(a => a.p_id == currentProject.p_id && a.t_status == 3 && a.t_done == false).ToList();
            foreach (task t in tasks3)
            {
                dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
            }
            List<task> tasks2 = db.task.Where(a => a.p_id == currentProject.p_id && a.t_status == 2 && a.t_done == false).ToList();
            foreach (task t in tasks2)
            {
                dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
            }
            List<task> tasks1 = db.task.Where(a => a.p_id == currentProject.p_id && a.t_status == 1 && a.t_done == false).ToList();
            foreach (task t in tasks1)
            {
                dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
            }
            List<task> tasks0 = db.task.Where(a => a.p_id == currentProject.p_id && a.t_status == 0 && a.t_done == false).ToList();
            foreach (task t in tasks0)
            {
                dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
            }
            List<task> tasks = db.task.Where(a => a.p_id == currentProject.p_id && a.t_done == false).ToList();
            foreach (task t in tasks)
            {
               // dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
                var sharedTasks = db.bridge_task_userdata.Where(a => a.t_id == t.t_id).ToList();
                if (sharedTasks.Count() > 1)
                {
                    dataGridView1.Rows[count].Cells[0].Style.ForeColor = Color.Blue;
                }
                count++;
            }
            
            int con = -1;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Name == "Column4")
                {
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        con++;
                        int p = Convert.ToInt32(r.Cells[3].Value);
                        if (p == 0)
                        {
                            dataGridView1.Rows[con].Cells[3].Value = "No Priority";
                            dataGridView1.Rows[con].Cells[3].Style.ForeColor = Color.Black;

                        }
                        if (p == 1)
                        {
                            dataGridView1.Rows[con].Cells[3].Value = "Low Priority";
                            dataGridView1.Rows[con].Cells[3].Style.ForeColor = Color.Brown;

                        }
                        if (p == 2)
                        {
                            dataGridView1.Rows[con].Cells[3].Value = "Medium Priority";
                            dataGridView1.Rows[con].Cells[3].Style.ForeColor = Color.Yellow;

                        }
                        if (p == 3)
                        {
                            dataGridView1.Rows[con].Cells[3].Value = "High Priority";
                            dataGridView1.Rows[con].Cells[3].Style.ForeColor = Color.Orange;

                        }
                        if (p == 4)
                        {
                            dataGridView1.Rows[con].Cells[3].Value = "Very High Priority";
                            dataGridView1.Rows[con].Cells[3].Style.ForeColor = Color.Red;

                        }


                    }
                }
                // button7.Hide();
            }
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                //  int time1 = t.notification(DateTime.Now, t.date_time_finish.Value);
                DateTime time1 = Convert.ToDateTime(r.Cells[2].Value);
                DateTime timeCurrent = DateTime.Now;
                if (time1 < timeCurrent.Date && time1 != null)
                {
                    r.DefaultCellStyle.BackColor = Color.Red;
                    // break;
                }
                //else
                //{
                //    r.DefaultCellStyle.BackColor = Color.White;
                //}

            }
            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                dataGridView1.Rows[j].Selected = false;
                // count++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

       
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                    task t = new task();
                    Data db = new Data();
                    t.t_name = (string)dataGridView1.CurrentRow.Cells[0].Value;
                    t = db.task.Where(a => a.t_name == t.t_name && a.p_id == currentProject.p_id).FirstOrDefault();
                    bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                    if (isChecked == false)
                    {
                        t.t_done = true;
                        doneTasksForToday += 1;
                        t.date_time_finish = DateTime.Now;
                        db.SaveChanges();
                        TaskPage tp = new TaskPage();
                        tp.Show();
                        this.Close();
                    }
                    else
                    {
                        t.t_done = false;

                        db.SaveChanges();
                    }
            }

        }
        //public string[] parseByLine(string Collaborators)
        //{
        //    string[] lines = Collaborators.Split('\n');
        //    return lines;
        //}

        private void button1_Click(object sender, EventArgs e)
        {

            Data db = new Data();

            userdata u = new userdata();
            userdata u2 = new userdata();

            task t = new task();

            project p = new project();

            bool check = true;
            int i = 0;

            string Try = (string)comboBox1.SelectedItem;

            string[] Collaborators = textBox3.Lines;


            t.t_name = textBox1.Text;
            t.content = textBox2.Text;
            t.date_time_created = DateTime.Now;
            t.date_time_finish = dateTimePicker1.Value;
            foreach (string c in Collaborators)
            {
                u2 = db.userdata.Where(a => a.u_email == c).FirstOrDefault();
                if (c != "" && u2 == null)
                {
                    check = false;
                    MessageBox.Show($"no user with {c}, please check the email written");
                    break;
                }
                if (c == currentUser.u_email)
                {
                    check = false;
                    MessageBox.Show("you can't add yourself");
                    break;
                }

            }
            if (Collaborators.Count() > 0)
            {
                if (check != false)
                    i++;
            }
            else
            {
                i++;
            }
            if (Try == null || Try == "No Priority")
            {
                t.t_status = 0;
            }
            else if (Try == "Low Priority")
            {
                t.t_status = 1;
            }
            else if (Try == "Medium Priority")
            {
                t.t_status = 2;
            }
            else if (Try == "High Priority")
            {
                t.t_status = 3;
            }
            else
            {
                t.t_status = 4;
            }
            //p = p.searchProject("Default", currentUser.u_id);
            //if (p == null)
            //    MessageBox.Show("it is null");
            currentProject = currentProject.searchProject(currentProject.p_name, currentUser.u_id);
            t.p_id = currentProject.p_id; // change to the pressed project id!!!!
            currentProject.number_of_tasks += 1;
            t.t_done = false;
            if (t.t_name == "")
            {
                MessageBox.Show("Enter a name for the task");
                return;
            }
            else if (t.searchForTask(t.t_name, (int)t.p_id) != null)
            {
                MessageBox.Show("Try a different name, there is already a task named like that in this project");
                return;
            }
            else
            {
                i++;
            }
            if (t.content == "")
            {
                MessageBox.Show("Enter the content for the task");
                return;
            }
            else
            {
                i++;
            }
            if (deadLineClicked == false)
            {
                MessageBox.Show("Enter the deadline for the task");
                return; 
            }
            else
            {
                i++;
            }
            if (t.date_time_finish < DateTime.Now.Date)
                MessageBox.Show($"invalid deadline, please enter date after{DateTime.Now}");
            else
            {
                if (i == 4)
                {
                    //t.userdata.Add(currentUser);
                    t.addTask(t, Collaborators);
                    if (imgPath != "")
                    {
                        string path = Environment.CurrentDirectory + "\\images\\task\\" + t.t_img + ".jpg";
                        File.Copy(imgPath, path);
                        t.t_img = path;

                    }
                    db.SaveChanges();
                    db.SaveChanges();
                    totalTasks += 1;
                    TaskPage tp = new TaskPage();
                    tp.Show();
                    this.Close();
                    //MessageBox.Show(t.userdata.First().u_name);
                }
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                //TaskPage tp = new TaskPage();
                task t = new task();
                t.t_name = (string)dataGridView1.CurrentRow.Cells[0].Value;
                t = t.searchForTask(t.t_name, currentProject.p_id);
                if (t != null)
                {
                    currentTask = t;
                    //  tp.Show();
                    update up = new update();
                    up.Show();
                    this.Close();
                    //this.Close();
                }


            }

            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           DashBoard dashBoard = new DashBoard();
            dashBoard.Show();   
            this.Close();    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProjectTask task = new ProjectTask();   
            task.Show();    
            this.Close();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            deadLineClicked = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        //Database db = new Database();
        //task t1 = new task();
        //string taskName = tb_search.Text;
        //t1.p_id = 3;
        //    t1.t_name = taskName;
        //    if (t1.searchTask(t1) != null)
        //        MessageBox.Show(t1.searchTask(t1).ToString());
        //    else
        //        MessageBox.Show("task is not found");
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Are you Sure You Deleted This Task", "Confirm deletion", MessageBoxButtons.YesNo);
            if (msg == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    TaskPage tp = new TaskPage();
                    task t = new task();
                    t.t_name = (string)dataGridView1.CurrentRow.Cells[0].Value;
                    t = t.searchForTask(t.t_name, currentProject.p_id);
                    t.deleteTask(t.t_name, currentProject.p_id);
                    MessageBox.Show("Task is deleted");
                    tp.Show();
                    this.Hide();
                }
            }
        }

        private void TaskPage_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);

        }

        private void TaskPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void taskname_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                textBox2.Focus();
            }
        }

        private void T_content_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                dateTimePicker1.Focus();
            }
        }

        private void dead_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                comboBox1.Focus();
            }
        }

        private void priority_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the beep sound
                textBox3.Focus();
            }
        }

        private void colla_keydown(object sender, KeyEventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            sharedTasks st = new sharedTasks();
            st.Show();
            this.Close();
        }

      
        private void button7_Click(object sender, EventArgs e)
        {
            string oldName, oldContent, oldPriorty;
            string Try = (string)comboBox1.SelectedItem;
            DateTime oldTime;
            oldName = currentTask.t_name;
            oldContent = currentTask.content;
            oldTime = currentTask.date_time_finish.Value;
            oldPriorty = (string)dataGridView1.CurrentRow.Cells[3].Value;
            Data db = new Data();
            currentTask.t_name = textBox1.Text;
            currentTask.content = textBox2.Text;
            currentTask.date_time_finish = dateTimePicker1.Value;
            if (Try == null || Try == "No Priority")
            {
                currentTask.t_status = 0;
            }
            else if (Try == "Low Priority")
            {
                currentTask.t_status = 1;
            }
            else if (Try == "Medium Priority")
            {
                currentTask.t_status = 2;
            }
            else if (Try == "High Priority")
            {
                currentTask.t_status = 3;
            }
            else
            {
                currentTask.t_status = 4;
            }
            if (textBox1.Text == oldName && textBox2.Text == oldContent && dateTimePicker1.Value == oldTime && comboBox1.Text == oldPriorty)
            {
                MessageBox.Show("not thing has been changed");
            }
            else
            {
                currentTask.updateTask(currentTask);
                db.SaveChanges();
                // MessageBox.Show("task has been updated");
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {

                    dataGridView1.Rows[i].Selected = false;
                }
                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(search.Text))
                {
                    //for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    //{
                    //    dataGridView1.Rows[j].Selected = false;

                    //}
                    dataGridView1.Rows[i].Selected = true;

                }



                // break;

            }
            if (string.IsNullOrWhiteSpace(search.Text))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    // count++;
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //OpenFileDialog img = new OpenFileDialog();



            //if (img.ShowDialog() == DialogResult.OK)
            //{
            //    imgPath = "";
            //    imgPath = img.FileName;
            //    pictureBox1.ImageLocation = img.FileName;
            //}
        }
    }
}
