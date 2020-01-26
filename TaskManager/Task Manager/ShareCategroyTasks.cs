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
    public partial class ShareCategroyTasks : Form
    {
        int cat_ID;
        List<Tasks> tk;
        int receiverID;
        public ShareCategroyTasks(int id)
        {
            cat_ID = id;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (cBCategory.SelectedIndex < 0)
                MessageBox.Show("Select Tasks");
            else
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString().Equals(cBCategory.SelectedItem))
                    {
                        MessageBox.Show("Already Added!!");
                        flag = false;
                    }

                }
                if (flag)
                    comboBox1.Items.Add(cBCategory.SelectedItem);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                MessageBox.Show("Select Task");
            else
            {
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskSer tS;
            List<int> taskIdList = new List<int>();
            int taskID;
            ShareTaskSer stS;
            int recID;
            UserSer uS = new UserSer();
            if (textBox1.Text != null)
            {
                if(uS.EmailValidity(textBox1.Text))
                {
                    if(comboBox1.Items.Count>0)
                    {
                        for(int i=0; i<comboBox1.Items.Count; i++)
                        {
                            tS = new TaskSer();
                            taskID = tS.GetTaskID(comboBox1.Items[i].ToString(),cat_ID);
                            taskIdList.Add(taskID);
                        }
                        uS = new UserSer();
                        recID = uS.GetUserIdByEmail(textBox1.Text);
                        
                        stS = new ShareTaskSer();
                        ShareTask st = new ShareTask();
                        st.Cat_ID = cat_ID;
                        st.SenderID = LogIn.user_ID;
                        st.ReceiverId = recID;
                        stS.Insert(st, LogIn.user_ID);

                        for (int i=0; i<taskIdList.Count; i++)
                        {
                            stS = new ShareTaskSer();
                            stS.Insert(cat_ID,taskIdList[i],LogIn.user_ID,recID);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Are you share all Project!!!!!!!");
                        uS = new UserSer();
                        recID = uS.GetUserIdByEmail(textBox1.Text);

                        stS = new ShareTaskSer();
                        ShareTask st = new ShareTask();
                        st.Cat_ID = cat_ID;
                        st.SenderID = LogIn.user_ID;
                        st.ReceiverId = recID;
                        stS.Insert(st, LogIn.user_ID);

                        TaskSer tkList = new TaskSer();
                        List<int> taskList = tkList.GetAllTaskID(cat_ID);
                        for(int i=0; i<taskList.Count; i++)
                        {
                            stS = new ShareTaskSer();
                            stS.Insert(cat_ID, taskList[i], LogIn.user_ID, recID);
                        }
                    }
                    MessageBox.Show("Tasks Are Shared!!!!!!!");
                    this.Close();
                }
                else
                    MessageBox.Show("Please Input Valid User Email Address!!");
            }
            else
                MessageBox.Show("Please Input Email Address!!");
        }

        private void ShareCategroyTasks_Load(object sender, EventArgs e)
        {
            TaskSer tS = new TaskSer();
            tk = tS.GetAllCompleteOrNotTask(0, cat_ID);
            for(int i=0; i<tk.Count; i++)
            {
                cBCategory.Items.Add(tk[i].Tittle);
            }
        }

        private void pictureBox2Today_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditShareTaskForm edF = new EditShareTaskForm();
            edF.Show();
        }
    }
}
