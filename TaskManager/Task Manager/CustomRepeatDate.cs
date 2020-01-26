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
    public partial class CustomRepeatDate : Form
    {

        int mov;
        int movX;
        int movY;

        public CustomRepeatDate()
        {
            InitializeComponent();
        }

        private void pBoxAddTaskView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = true;
            textBox2.Visible = false;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = false;
            textBox2.Visible = false;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = false;
            textBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (UpdateAddTaskInfo.updateAddTaskInfo == null)
            //{
                int val = Convert.ToInt32(textBox1.Text); ;
                int noOfOcc = 0;
                int end;
                DateTime dt = new DateTime();
                List<string> weeksName = new List<string>();
                if (radioButton1.Checked == true)
                {
                    end = 1;
                }
                else if (radioButton2.Checked == true)
                {
                    end = 2;
                    dt = dateTimePicker2.Value;
                }
                else
                {
                    end = 3;
                    noOfOcc = Convert.ToInt32(textBox2.Text);
                }
                if (comboBox1.SelectedItem.ToString().Equals("Weeks"))
                {
                    for (int i = 0; i < comboBox3.Items.Count; i++)
                    {
                        weeksName.Add(comboBox3.Items[i].ToString());
                    }
                    if (end == 1)
                    {
                        AddTaskView.addTaskView.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), weeksName, 0);
                    }
                    else if (end == 2)
                    {
                        AddTaskView.addTaskView.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), weeksName, dt);
                    }
                    else
                        AddTaskView.addTaskView.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), weeksName, noOfOcc);

                }
                else
                {
                    if (end == 1)
                    {
                        AddTaskView.addTaskView.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), 0);
                    }
                    else if (end == 2)
                    {
                        AddTaskView.addTaskView.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), dt);
                    }
                    else
                        AddTaskView.addTaskView.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), noOfOcc);
                }
            //}
            //else
            //{
            //    int val = Convert.ToInt32(textBox1.Text); ;
            //    int noOfOcc = 0;
            //    int end;
            //    DateTime dt = new DateTime();
            //    List<string> weeksName = new List<string>();
            //    if (radioButton1.Checked == true)
            //    {
            //        end = 1;
            //    }
            //    else if (radioButton2.Checked == true)
            //    {
            //        end = 2;
            //        dt = dateTimePicker2.Value;
            //    }
            //    else
            //    {
            //        end = 3;
            //        noOfOcc = Convert.ToInt32(textBox2.Text);
            //    }
            //    if (comboBox1.SelectedItem.ToString().Equals("Weeks"))
            //    {
            //        for (int i = 0; i < comboBox3.Items.Count; i++)
            //        {
            //            weeksName.Add(comboBox3.Items[i].ToString());
            //        }
            //        if (end == 1)
            //        {
            //            UpdateAddTaskInfo.updateAddTaskInfo.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), weeksName, 0);
            //        }
            //        else if (end == 2)
            //        {
            //            UpdateAddTaskInfo.updateAddTaskInfo.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), weeksName, dt);
            //        }
            //        else
            //            UpdateAddTaskInfo.updateAddTaskInfo.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), weeksName, noOfOcc);

            //    }
            //    else
            //    {
            //        if (end == 1)
            //        {
            //            //MessageBox.Show(comboBox1.SelectedItem.ToString());
            //            UpdateAddTaskInfo.updateAddTaskInfo.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), 0);
            //        }
            //        else if (end == 2)
            //        {
            //            UpdateAddTaskInfo.updateAddTaskInfo.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), dt);
            //        }
            //        else
            //            UpdateAddTaskInfo.updateAddTaskInfo.AddCustomRepeatedDate(val, comboBox1.SelectedItem.ToString(), noOfOcc);
            //    }
            //}

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (comboBox2.SelectedIndex < 0)
                MessageBox.Show("Select Reminder");
            else
            {
                for (int i = 0; i < comboBox3.Items.Count; i++)
                {
                    if (comboBox3.Items[i].ToString().Equals(comboBox2.SelectedItem))
                    {
                        MessageBox.Show("Already Added!!");
                        flag = false;
                    }

                }
                if (flag)
                    comboBox3.Items.Add(comboBox2.SelectedItem);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex < 0)
                MessageBox.Show("Select Reminder");
            else
            {
                comboBox3.Items.Remove(comboBox3.SelectedItem);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString().Equals("Weeks"))
                panel1.Visible = true;
            else
                panel1.Visible = false;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
    }
}
