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
using static c_project.DashBoard;
namespace c_project
{
    public partial class sharedTasks : Form
    {
        public sharedTasks()
        {
            InitializeComponent();
        }

        private void sharedTasks_Load(object sender, EventArgs e)
        {
            Data db = new Data();
            List<bridge_task_userdata> bridgeTasks = db.bridge_task_userdata.Where(a => a.u_id == currentUser.u_id).ToList();
            foreach (bridge_task_userdata b in bridgeTasks)
            {
                var tasks = db.task.Where(a=> a.t_id == b.t_id);
                foreach (task t in tasks)
                {
                    var proj = db.project.Where(a => a.p_id == t.p_id).FirstOrDefault();
                    if (proj.u_id != currentUser.u_id)
                    {
                        dataGridView1.Rows.Add(t.t_name, t.date_time_created, t.date_time_finish, t.t_status, t.t_done, t.p_id);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TaskPage tp = new TaskPage();
            tp.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("are you sure you want to remove this task? you won't be part of this task anymore", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Data db = new Data();
                    task t = new task();
                    bridge_task_userdata br = new bridge_task_userdata();
                    t.t_name = (string)dataGridView1.CurrentRow.Cells[0].Value;
                    t.p_id = (int)dataGridView1.CurrentRow.Cells[5].Value;
                    t = t.searchForTask(t.t_name, (int)t.p_id);
                    br = db.bridge_task_userdata.Where(a => a.t_id == t.t_id && a.u_id == currentUser.u_id).FirstOrDefault();
                    db.bridge_task_userdata.Remove(br);
                    db.SaveChanges();
                    sharedTasks st = new sharedTasks();
                    st.Show();
                    this.Close();
                }
            }
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    doneTasksForToday -= 1;

                    db.SaveChanges();
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                sharedTasks tp = new sharedTasks();
                Data db = new Data();
                task t = new task();
                t.t_name = (string)dataGridView1.CurrentRow.Cells[0].Value;
                t.p_id = (int)dataGridView1.CurrentRow.Cells[5].Value;
                t = t.searchForTask(t.t_name, (int)t.p_id);
                if (t != null)
                {
                    currentTask = t;
                    tp.Show();
                    this.Close();
                }


            }

            update up = new update();
            up.Show();
            this.Close();
        }
    }
}
