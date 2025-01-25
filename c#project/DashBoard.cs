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
using static c_project.ProjectTask;
using static c_project.SignUp;

namespace c_project
{
    public partial class DashBoard : Form
    {
        int numofneartask;
        bool sidebarExband;
        public static int totalTasks;
        public static int doneTasksForToday;
        private DateTime lastClickTime = DateTime.Now;
       
        public DashBoard()
        {
            InitializeComponent();
            progressBar1.Maximum = totalTasks;
            progressBar1.Value = doneTasksForToday;
            string text = $"Tasks Done For This Week\n{doneTasksForToday} / {totalTasks}";
            button3.Text = text;
            if (currentUser == null)
            {
                //MessageBox.Show("null");
            }
            else
                {
                if (currentUser.img != null)
                {
                    pictureBox2.Image = System.Drawing.Image.FromFile(currentUser.img);
                }
                label5.Text = currentUser.u_name;
            }


        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
           
        }
        
        

        

       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Sidebartimer_Tick(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void tb_search_keypress(object sender, KeyPressEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TaskPage taskpage = new TaskPage();
            taskpage.Show();
            this.Close();    
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectTask taskpage = new ProjectTask();
            taskpage.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load_1(object sender, EventArgs e)
        {
            label6.Hide();
            textBox1.Hide();
                Data db = new Data();
            bridge_task_userdata br = new bridge_task_userdata();
            int count = 0;
            List<project> projects = db.project.Where(a => a.u_id == currentUser.u_id).ToList();
            foreach (project p in projects)
            {
                var tasks = db.task.Where(a => a.t_done == true && a.p_id == p.p_id).ToList();
                foreach (task t in tasks)
                {
                    dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
                    var sharedTasks = db.bridge_task_userdata.Where(a => a.t_id == t.t_id).ToList();
                    if (sharedTasks.Count() > 1)
                    {
                        dataGridView1.Rows[count].Cells[0].Style.ForeColor = Color.Blue;
                    }
                    count++;
                }
            }
            // Data db = new Data();
            List<project> projs = db.project.Where(a => a.u_id == currentUser.u_id).ToList();
            foreach (project p in projs)
            {
                // MessageBox.Show(p.p_name);
                currentProject = p;
                //dataGridView2.Rows.Add(p.p_name, p.number_of_tasks, p.p_done);
                List<task> tasks = db.task.Where(a => a.p_id == currentProject.p_id && a.t_done == false).ToList();
                foreach (task t in tasks)
                {
                    //dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
                    int time = t.notification(DateTime.Now.Date, t.date_time_finish.Value.Date);
                    if (time == 0)
                    {
                        numofneartask++;
                       // MessageBox.Show($"{t.t_name} task in project {p.p_name} will be end{time}");


                    }
                }
            }
            if (numofneartask > 0)
            {
                label6.Show();
                textBox1.Show();
                textBox1.Text = numofneartask.ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Setting setting = new Setting();    
            setting.Show();
            this.Close();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProjectTask taskpage = new ProjectTask();

            taskpage.Show();
            this.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TaskPage taskpage = new TaskPage();
            project p = new project();
            p.p_name = "Default";
            currentProject = p.searchProject(p.p_name, currentUser.u_id);
            if (currentProject == null)
                MessageBox.Show("null");
            taskpage.Show();
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
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
                }
                else
                {
                    t.t_done = false;
                    doneTasksForToday -= 1;
                    db.SaveChanges();
                    DashBoard d = new DashBoard();
                    d.Show();
                    this.Close();
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                currentUser = null;
                home h = new home();
                h.Show();
                this.Close();
            }
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Data db = new Data();
            List<project> projs = db.project.Where(a => a.u_id == currentUser.u_id).ToList();
            foreach (project p in projs)
            {
                // MessageBox.Show(p.p_name);
                currentProject = p;
                //dataGridView2.Rows.Add(p.p_name, p.number_of_tasks, p.p_done);
                List<task> tasks = db.task.Where(a => a.p_id == currentProject.p_id&&a.t_done == false).ToList();
                foreach (task t in tasks)
                {
                    //dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done);
                    int time = t.notification(DateTime.Now.Date, t.date_time_finish.Value.Date);
                    if (time == 0)
                    {
                       // numofneartask++;
                        MessageBox.Show($"{t.t_name} task in project {p.p_name} will end soon");


                    }
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
