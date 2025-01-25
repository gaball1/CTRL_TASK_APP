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
using System.Linq;
using static c_project.DashBoard;

using static c_project.SignUp;

namespace c_project
{

    public partial class ProjectTask : Form
    {
        public Point mouseLocation;

        private DateTime lastClickTime = DateTime.Now;
        private DataGridViewCellEventArgs lastCellClickEventArgs;


        public ProjectTask()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();
            this.KeyPreview = true;
            dataGridView2.CellClick += DataGridViewCellClick;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProjectTask_Load(object sender, EventArgs e)
        {
            Data db = new Data();
            //textBox2.Hide();
            //label2.Hide();

            List<project> projs = db.project.Where(a => a.u_id == currentUser.u_id).ToList();
            foreach (project p in projs)
            {
                dataGridView2.Rows.Add(p.p_name, p.number_of_tasks);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //private void update(string name)
        //{
        //    Database db = new Database();
        //    project p = new project();
        //    p.p_name = textBox1.Text;
        //    if (p.p_name != "Default")
        //    {
        //        p = p.searchProject(p.p_name, currentUser.u_id);
        //        if (p != null)
        //        {
        //            p.p_name = name;
        //            p.updateProject(p);
        //            MessageBox.Show("project is updated");
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No Project with that name");
        //        }
        //    }
        //}
        private void button3_Click(object sender, EventArgs e)
        {
            //textBox2.Show();
            //label2.Show();
            //string name = textBox2.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            project p = new project();
            project p2 = new project();
            p.p_name = textBox1.Text;
            p.u_id = currentUser.u_id;
            //p.p_done = false;
            p.number_of_tasks = 0;
            if (p.p_name != "")
            {
                p2 = p.searchProject(p.p_name, currentUser.u_id);
                if (p2 == null)
                {
                    p.addProject(p);
                    Data db = new Data(); db.SaveChanges();
                    MessageBox.Show("the project has been created");
                    ProjectTask pt = new ProjectTask();
                    pt.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("there is already a project with that name");
                }
               
            }
            else
            {
                MessageBox.Show("Enter a name for the project");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
        //    Database db = new Database();
        //    project p = new project();
        //    p.p_name = tb_search.Text;
        //    p = p.searchProject(p.p_name, currentUser.u_id);
        //    if (p != null)
        //    {
        //        for (int i = 0; i < dataGridView2.Rows.Count  ;i++)
        //        {
        //            dataGridView2.Rows.RemoveAt(i);
        //        }
        //        List<project> projs = db.projects.Where(a => a.p_name == p.p_name).ToList();
        //        foreach (project project in projs)
        //        {
        //            dataGridView2.Rows.Add(project.p_name, project.number_of_tasks, project.p_done);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No Project with that name");
        //    }
        }

       
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                TaskPage tp = new TaskPage();
                currentProject.p_name = (string)dataGridView2.CurrentRow.Cells[0].Value;
                currentProject = currentProject.searchProject(currentProject.p_name, currentUser.u_id);
                tp.Show();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DashBoard d = new DashBoard();
            d.Show();
            this.Close();
        }   

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            var msg = MessageBox.Show("Are You Sure You Deleted This Project", "Confirm deletion", MessageBoxButtons.YesNo);
            TaskPage tp = new TaskPage();
            ProjectTask pt = new ProjectTask();
            Data db = new Data();
            project p = new project();
            project p2 = new project();
            if (dataGridView2.CurrentRow != null)
            {
                if (msg == DialogResult.Yes)
                {
                    p.p_name = (string)dataGridView2.CurrentRow.Cells[0].Value;

                    if (p.p_name != "Default")
                    {
                        p = p.searchProject(p.p_name, currentUser.u_id);
                        if (p != null)
                        {
                            p.deleteProject(p.p_name, currentUser.u_id);
                            pt.Show();
                            this.Close();
                            MessageBox.Show("project is deleted");
                            p2 = db.project.Where(a => a.p_name == p.p_name).FirstOrDefault();
                            db.project.Remove(p2);
                            db.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("No Project with that name");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can not delete the default");
                    }
                }
                
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProjectTask_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);

        }

        private void ProjectTask_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void projectname_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                button1.Focus();
            }
        }

        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                TimeSpan timeSinceLastClick = DateTime.Now - lastClickTime;

                if (timeSinceLastClick.TotalMilliseconds < (SystemInformation.DoubleClickTime - .01))
                {
                    TaskPage tp = new TaskPage();
                    currentProject.p_name = (string)dataGridView2.Rows[e.RowIndex].Cells[0].Value;
                    currentProject = currentProject.searchProject(currentProject.p_name, currentUser.u_id);
                    tp.Show();
                    this.Close();
                }
                lastClickTime = DateTime.Now;
                lastCellClickEventArgs = e;
            }
        }
        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            //Data db = new Data();
            //var res = dataGridView2.Columns.Contains(search.Text).ToString();
            ////   var s = db.projects.Where(x => x.p_name.Contains(search.Text)&&x.u_id==currentUser.u_id);
            //if (res != null)
            //    dataGridView2.DataSource = res.ToList();
            //else
            //    dataGridView2.DataSource = db.project.ToList();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {

                    dataGridView2.Rows[i].Selected = false;
                }
                if (dataGridView2.Rows[i].Cells[0].Value.ToString().Contains(search.Text))
                {
                    //for (int j = 0; j < dataGridView2.Rows.Count; j++)
                    //{
                    //    dataGridView2.Rows[j].Selected = false;

                    //}
                    dataGridView2.Rows[i].Selected = true;
                }



                // break;

            }
            if (string.IsNullOrWhiteSpace(search.Text))
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    dataGridView2.Rows[i].Selected = false;
                    // count++;
                }
            }
        }
    }
}
