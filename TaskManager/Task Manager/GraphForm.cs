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
    public partial class GraphForm : Form
    {

        int mov;
        int movX;
        int movY;


        public GraphForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex < 0 && comboBox1.SelectedIndex >= 0)
            {
                LoadGraphPoint(comboBox1.SelectedIndex+1,DateTime.Now.Year);
            }
            else if(comboBox2.SelectedIndex >= 0 && comboBox1.SelectedIndex < 0)
            {
                LoadGraphPoint(1, Convert.ToInt32(comboBox2.SelectedItem.ToString()));
            }
            else
            {
                LoadGraphPoint(comboBox1.SelectedIndex + 1, Convert.ToInt32(comboBox2.SelectedItem.ToString()));
            }
        }

        public void InitialLoadDataInGraph()
        {
            List<string> dateList = new List<string>();
            List<int> noOfCompleteTaskList = new List<int>();

            TaskSer tS = new TaskSer();
            int noOfCompleteTask = 0;
            DateTime dt = DateTime.Now;
            string date = dt.ToShortDateString();
            int noOfDateAdd = 0;
            for (int i = 1; i <= 30; i++)
            {
                noOfCompleteTask = tS.GetAllCompleteTaskCountByDate(date);
                if (noOfCompleteTask == 0)
                    continue;
                noOfCompleteTaskList.Add(noOfCompleteTask);
                dateList.Add(date);
                dt = dt.AddDays(-1);
                date = dt.ToShortDateString();
                noOfDateAdd++;
            }

            chart1.Series["Task"].Points.DataBindXY(dateList, noOfCompleteTaskList);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.Title = "Dates";
            chart1.ChartAreas[0].AxisY.Title = "Task Completed";
            for (int i = 0; i < noOfDateAdd; i++)
            {
                chart1.Series["Task"].Points[i].Color = Color.FromArgb(i + 21, i + 29, i + 78);
            }
        }
        public void LoadGraphPoint(int mon, int year)
        {
            List<string> dateList = new List<string>();
            List<int> noOfCompleteTaskList = new List<int>();


            DateTime date1 = new DateTime(year, mon, 1);

            
            TaskSer tS = new TaskSer();
            int noOfCompleteTask = 0;

            string date = date1.ToShortDateString();

            for (int i = 1; i <= 30; i++)
            {
                noOfCompleteTask = tS.GetAllCompleteTaskCountByDate(date);
                if (noOfCompleteTask != 0)
                {
                    noOfCompleteTaskList.Add(noOfCompleteTask);
                    dateList.Add(date);
                }
                
                date1 = date1.AddDays(1);
                date = date1.ToShortDateString();
            }

            if (noOfCompleteTaskList.Count == 0)
                MessageBox.Show("There are no task complete in this months");
            else
            {
                chart1.Series["Task"].Points.DataBindXY(dateList, noOfCompleteTaskList);
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart1.ChartAreas[0].AxisY.Title = "Dates";
                chart1.ChartAreas[0].AxisY.Title = "Task Completed";
                for (int i = 0; i < dateList.Count; i++)
                {
                    chart1.Series["Task"].Points[i].Color = Color.FromArgb(i + 21, i + 29, i + 78);
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GraphForm_Load(object sender, EventArgs e)
        {
            InitialLoadDataInGraph();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
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
    }
}
