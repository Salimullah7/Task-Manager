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
    public partial class EditShareTaskForm : Form
    {

        int mov;
        int movX;
        int movY;


        public EditShareTaskForm()
        {
            InitializeComponent();
        }

        private void pictureBox2Today_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditShareTaskForm_Load(object sender, EventArgs e)
        {
            //List<int> catIDList = new List<int>();
            List<int> userIDList = new List<int>();
            
            ShareTaskSer uS = new ShareTaskSer();
            //MessageBox.Show(LogIn.user_ID.ToString());
            List<ShareTask> sList = uS.GetAllShared(LogIn.user_ID);
            //MessageBox.Show(sList[0].ReceiverId.ToString());
            //CategorySer catS;
            UserSer userS;
            //string na;
            string email;
            for (int i=0; i<sList.Count; i++)
            {
                userS = new UserSer();
                email = userS.GetUserEmail(sList[i].ReceiverId);
                //MessageBox.Show(email);
                //catS = new CategorySer();
                //na = catS.GetCategoryName(sList[i].Cat_ID,LogIn.user_ID);
                //comboBox3.Items.Add(na);
                comboBox2.Items.Add(email);
            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex < 0)
                MessageBox.Show("Select Category!!!!");
            else
            {
                string catName = comboBox3.SelectedItem.ToString();
                CategorySer catS = new CategorySer();
                int catID = catS.GetCategoryID(catName, LogIn.user_ID);
                ShareTaskSer tS = new ShareTaskSer();
                List<int> tkIDList = tS.GetAllTasksFromShareTasks(catID);
                TaskSer taskService;
                string tittle;
                for (int i = 0; i < tkIDList.Count; i++)
                {
                    taskService = new TaskSer();
                    tittle = taskService.GetTaskTittle(catID, tkIDList[i]);
                    cBCategory.Items.Add(tittle);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
                MessageBox.Show("Select User Email!!!!");
            else
            {
                string uEmail = comboBox2.SelectedItem.ToString();

                UserSer userS = new UserSer();
                int uID = userS.GetUserIdByEmail(uEmail);
                ShareTaskSer uS = new ShareTaskSer();
                List<int> catIDList = uS.GetCategoryID(LogIn.user_ID, uID);
                //MessageBox.Show(catIDList.Count.ToString());
                CategorySer cS;
                List<string> catNameList = new List<string>();
                string catName;

                for(int i=0; i<catIDList.Count; i++)
                {
                    cS = new CategorySer();
                    //MessageBox.Show(catIDList[i].ToString());
                    catName = cS.GetCategoryName(catIDList[i], LogIn.user_ID);
                    catNameList.Add(catName);
                }

                for(int i=0; i<catNameList.Count; i++)
                {
                    comboBox3.Items.Add(catNameList[i]);
                }
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (cBCategory.SelectedIndex < 0)
                MessageBox.Show("Select Reminder");
            else
            {
                UserSer userS = new UserSer();
                int viewerID = userS.GetUserIdByEmail(comboBox2.SelectedItem.ToString());
                CategorySer cg = new CategorySer();
                int catID = cg.GetCategoryID(comboBox3.SelectedItem.ToString(), LogIn.user_ID);
                TaskSer tS = new TaskSer();

                //MessageBox.Show(cBCategory.SelectedItem.ToString());
                
                
                int taskID = tS.GetTaskID(cBCategory.SelectedItem.ToString(), catID);
                userS = new UserSer();
                userS.Delete(viewerID, LogIn.user_ID, catID, taskID);
                cBCategory.Items.Remove(cBCategory.SelectedItem);
                cBCategory.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
                MessageBox.Show("Select Reminder");
            else
            {
                UserSer userS = new UserSer();
                int viewerID = userS.GetUserIdByEmail(comboBox2.SelectedItem.ToString());
                userS = new UserSer();
                userS.Delete(viewerID, LogIn.user_ID);
                ShareTaskSer uS = new ShareTaskSer();
                uS.Delete(viewerID);
                comboBox2.Items.Remove(comboBox2.SelectedItem);
                comboBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex < 0)
                MessageBox.Show("Select Reminder");
            else
            {
                UserSer userS = new UserSer();
                int viewerID = userS.GetUserIdByEmail(comboBox2.SelectedItem.ToString());
                CategorySer cg = new CategorySer();
                int catID = cg.GetCategoryID(comboBox3.SelectedItem.ToString(), LogIn.user_ID);
                userS = new UserSer();
                userS.Delete(viewerID, LogIn.user_ID, catID);
                comboBox3.Items.Remove(comboBox3.SelectedItem);
                comboBox3.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
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
    }
}
