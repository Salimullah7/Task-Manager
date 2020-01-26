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
    public partial class CustomNoficationForm : Form
    {

        int mov;
        int movX;
        int movY;


        public CustomNoficationForm()
        {
            InitializeComponent();
        }

        private void pBoxAddTaskView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomNoficationForm_Load(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
            radioButton5.Checked = true;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null)
            {
                int notifyNo;
                string time;
                if (radioButton1.Checked == true)
                    time = " Days before";
                else if(radioButton2.Checked == true)
                    time = " Hours before";
                else if (radioButton3.Checked == true)
                    time = " Minutes before";
                else
                    time = " Weeks before";


                if (radioButton5.Checked == true)
                    notifyNo = 1;
                else if (radioButton6.Checked == true)
                    notifyNo = 2;
                else
                    notifyNo = 3;

                if(UpdateAddTaskInfo.updateAddTaskInfo != null)
                    UpdateAddTaskInfo.updateAddTaskInfo.AddCustomNotification(Convert.ToInt32(textBox1.Text), time, notifyNo);
                else
                    AddTaskView.addTaskView.AddCustomNotification(Convert.ToInt32(textBox1.Text),time,notifyNo);
                this.Close();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
    }
}
