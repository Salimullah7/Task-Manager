using Entity;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager
{
    public partial class AddTaskInfoInBig : Form
    {
        public static AddTaskInfoInBig addTaskInfoBig;
        Tasks obj;

        int mov;
        int movX;
        int movY;


        public AddTaskInfoInBig()
        {
            addTaskInfoBig = this;
            InitializeComponent();
        }
        public void SetAllInfo(Tasks obj)
        {
            this.obj = obj;
            label4.Text = obj.Tittle;
            label7.Text = obj.Date;
            label8.Text = obj.Time;

            if (obj.Priority == 1)
                label11.Text = "Low";
            else if (obj.Priority == 2)
                label11.Text = "Medium";
            else
                label11.Text = "High";

            label2.Text = obj.Description;

            if(obj.RepeatName == "")
                label13.Text = "Doesn't Repeat";
            else
                label13.Text = obj.RepeatName;


            for (int i=0; i<obj.Notify_Time_List.Count; i++)
            {
                listBox1.Items.Add(obj.Notify_Time_List[i].NotifyTimeBeforeString);
            }
            

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            //UpdateAddTaskInfo.updateAddTaskInfo = new UpdateAddTaskInfo();
            //UpdateAddTaskInfo.updateAddTaskInfo.Show();
            //UpdateAddTaskInfo.updateAddTaskInfo.SetAllInfo(obj);


            AddTaskView adF = new AddTaskView();
            adF.Show();

            adF.LoadDataInfoOfTask(obj);



        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();

            TaskSer tSer = new TaskSer();
            int noOfTaskSimilar = tSer.GetNoOfTaskOfRepeatID(obj.RepeatDateTask_ID);

            if(noOfTaskSimilar > 1)
                if(MessageBox.Show("Are you want to delete all task which is following this task.","Hello",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tSer.DeleteByRepeatID(obj.RepeatDateTask_ID);
                }
                else
                {
                    tSer.Delete(obj.Task_ID);
                }
            else
            {
                tSer.Delete(obj.Task_ID);
            }
            MessageBox.Show("Task Is Deleted");
            UserControlForOnlyTestPurpose.uC.LoadTaskList();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
