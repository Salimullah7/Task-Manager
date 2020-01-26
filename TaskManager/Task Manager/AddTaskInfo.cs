using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using System.Threading;
using Entity;

namespace Task_Manager
{
    public partial class AddTaskInfo : UserControl
    {
        public AddTaskInfo()
        {
            InitializeComponent();
        }

        string _title;
        string _date;
        int _task_ID;
        Image _icon;

        public string Tittle
        {
            get { return _title; }
            set { _title = value; lblTilte.Text = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; lblDate.Text = value; }
        }
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pBoxTaskComplete.Image = _icon; }
        }
        public int Task_ID
        {
            get { return _task_ID; }
            set { _task_ID = value; }
        }

        private void pBoxTaskComplete_Click(object sender, EventArgs e)
        {
            if(Icon == null)
            {
                Bitmap img = new Bitmap("C:\\Users\\sajib\\source\\repos\\Task Manager\\image\\checkmark.png");
                Icon = img;

                pBoxTaskComplete.Refresh();
                Thread.Sleep(1000);

                TaskSer taskS = new TaskSer();
                taskS.Update(Task_ID, 1);

                //HomePage2.home2.Close();
                //HomePage2.home2 = new HomePage2();
                //HomePage2.home2.Show();

                UserControlForOnlyTestPurpose.uC.LoadTaskList();
                
            }
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AddTaskInfoInBig adIB = new AddTaskInfoInBig();
            adIB.Show();

            TaskSer taskService = new TaskSer();
            Tasks ts = taskService.GetAllInfoByTaskID(Task_ID);
            adIB.SetAllInfo(ts);
        }
    }
}
