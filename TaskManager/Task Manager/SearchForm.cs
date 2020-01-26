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
    public partial class SearchForm : Form
    {
        int mov;
        int movX;
        int movY;
        string searchString;
        TaskSer ts;
        List<Tasks> taskList;

        public SearchForm()
        {
            InitializeComponent();
            ts = new TaskSer(); 
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            listBox1.Items.Clear();
            if (e.KeyChar == (char)8)
            {
                searchString = searchString.Remove(searchString.Length - 1);
                taskList = ts.GetSearchByChacter(searchString);
                for (int i = 0; i < taskList.Count; i++)
                {
                    listBox1.Items.Add(taskList[i].Task_ID + " - " + taskList[i].Tittle + " - " + taskList[i].Date + " - " + taskList[i].Time);
                }
            }
            else
            {
                searchString += e.KeyChar;
                taskList = ts.GetSearchByChacter(searchString);
                for (int i = 0; i < taskList.Count; i++)
                {
                    listBox1.Items.Add(taskList[i].Task_ID + " - " + taskList[i].Tittle + " - " + taskList[i].Date + " - " + taskList[i].Time);
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string taskName = listBox1.SelectedItem.ToString();
            String[] spearator = {"-"};

            String[] strlist = taskName.Split(spearator,StringSplitOptions.RemoveEmptyEntries);
            MessageBox.Show(strlist[0]);

            Tasks task = ts.GetAllInfoByTaskID(Convert.ToInt32(strlist[0]));

            AddTaskInfoInBig adBig = new AddTaskInfoInBig();
            adBig.Show();
            adBig.SetAllInfo(task);
        }
    }
}
