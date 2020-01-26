using Entity;
using Microsoft.Win32;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager
{
    public partial class Only_Test_Purpose : Form
    {
        string a;
        SmtpClient client;
        MailMessage msg;
        public Only_Test_Purpose()
        {
            InitializeComponent();

        }
        private void Only_Test_Purpose_Load(object sender, EventArgs e)
        {
            //RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //reg.SetValue("My New Application", Application.ExecutablePath.ToString());
            //timer1.Start();


            List<string> dateList = new List<string>();
            List<int> noOfCompleteTaskList = new List<int>();

            TaskSer tS = new TaskSer();
            int noOfCompleteTask = 0;
            DateTime dt = DateTime.Now;
            string date = dt.ToShortDateString();
            //string chartDate = dt.ToString("dd/mm");
            int noOfDateAdd = 0;
            for(int i=1; i<=30; i++)
            {
                noOfCompleteTask = tS.GetAllCompleteTaskCountByDate(date);
                if (noOfCompleteTask == 0)
                    continue;
                noOfCompleteTaskList.Add(noOfCompleteTask);
                dateList.Add(date);
                //chart1.Series["Task Complete"].Points.AddXY(chartDate, noOfCompleteTask);
                dt = dt.AddDays(-1);
                date = dt.ToShortDateString();
                noOfDateAdd++;
                //chartDate = dt.ToString("dd/mm");
            }

            chart1.Series["Task Complete"].Points.DataBindXY(dateList,noOfCompleteTaskList);
            //chart1.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.Title = "Dates";
            chart1.ChartAreas[0].AxisY.Title = "Task Completed";
            for (int i=0; i< noOfDateAdd; i++)
            {
                chart1.Series["Task Complete"].Points[i].Color = Color.FromArgb(i+21,i+29, i+78);
            }

        }

    }
}
