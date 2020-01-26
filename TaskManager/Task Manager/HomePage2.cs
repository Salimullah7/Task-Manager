using Entity;
using Repositories;
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
    public partial class HomePage2 : Form
    {
        ProjectUserControl pUC;
        public static int scrollPos;
        public static HomePage2 home2;
        int category_ID;
        static string CategoryName;
        UserSer us;
        static int count = 0;


        //After

        static bool checkFormLoadFirstTime = false;

        int mov;
        int movX;
        int movY;




        public HomePage2()
        {
            home2 = this;
            InitializeComponent();
            //data = new DataAccess();
            //us = new UserSer();

            UserControlForOnlyTestPurpose.uC = userControlForOnlyTestPurpose2;


        }




        public HomePage2(int catID)
        {
            home2 = this;
            category_ID = catID;
            InitializeComponent();
            //data = new DataAccess();
            //us = new UserSer();
        }

        public HomePage2(string catName)
        {
            home2 = this;
            InitializeComponent();
            CategoryName = catName;
            //data = new DataAccess();
            //us = new UserSer();
        }

        public void CategoryListShow()
        {
            flowLayoutPanel2.Controls.Clear();
            CategorySer catS = new CategorySer();
            List<Category> catList = catS.GetAll(LogIn.user_ID);

            for (int i = 0; i < catList.Count; i++)
            {
                if (catList[i].Name.Equals("Inbox") || catList[i].Name.Equals("Today") || catList[i].Name.Equals("Next 7 Day"))
                    continue;
                pUC = new ProjectUserControl();
                pUC.ProjectName = catList[i].Name;
                pUC.ProjectColor = catList[i].Color;
                flowLayoutPanel2.Controls.Add(pUC);
            }
        }
        private void ChangeBackColor(object sender, EventArgs e)
        {
            this.pUC.ForeColor = Color.Yellow;
        }
        private void TaskListShow(FlowLayoutPanel flow, int catID)
        {
            TaskSer taskS = new TaskSer();
            List<Tasks> taskList = taskS.GetAll(catID);

            for (int i = 0; i < taskList.Count; i++)
            {
                AddTaskInfo pUC = new AddTaskInfo();
                pUC.Tittle = taskList[i].Tittle;
                pUC.Date = Convert.ToDateTime(taskList[i].Date).ToLongDateString();
                pUC.Task_ID = taskList[i].Task_ID;
                flow.Controls.Add(pUC);
            }
        }

        public void setLabelAndCategoryID(string name)
        {
            try
            {
                if (!(flowLayoutPanel2.VerticalScroll.Value == 0 && scrollPos != 0))
                    scrollPos = flowLayoutPanel2.VerticalScroll.Value;



                HomePage2.home2.Close();
                HomePage2.home2 = new HomePage2(name);
                HomePage2.home2.Show();





                if (0 == flowLayoutPanel2.VerticalScroll.Value)
                    HomePage2.home2.flowLayoutPanel2.VerticalScroll.Value = 0;
                else
                    HomePage2.home2.flowLayoutPanel2.VerticalScroll.Value = scrollPos;
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
            //panel4.BringToFront();
        }
        
        private void btnInbox_Click(object sender, EventArgs e)
        {

            //After

            try
            {
                //CategoryListShow();
                CategorySer s = new CategorySer();
                int catID = s.GetCategoryID("Inbox", LogIn.user_ID);

                TaskSer taskS = new TaskSer();
                List<Tasks> taskList = taskS.GetAll(catID);
                UserControlForOnlyTestPurpose.uC.Project_Name = "Inbox";
                UserControlForOnlyTestPurpose.uC.LoadTaskList(taskList);

            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
            }


        }

        public void ContentFormLoad(string name)
        {
            //CategoryListShow();
            ContentUserControl cuc = new ContentUserControl();
            cuc.ProjectName = name;
            CategorySer s = new CategorySer();
            int cat_ID = s.GetCategoryID(name, LogIn.user_ID);
            TaskListShow(cuc.Flow, cat_ID);
            panel4.Controls.Add(cuc);
        }

        private void pBoxAddTaskView_Click(object sender, EventArgs e)
        {
            AddTaskView adt = new AddTaskView();
            adt.Show();
        }

        private void btnProject_Click_1(object sender, EventArgs e)
        {
            CategoriesView cat = new CategoriesView();
            cat.Show();
        }

        private void HomePage2_Load(object sender, EventArgs e)
        {


            //Before

            //CategoryListShow();

            //ContentUserControl cuc = new ContentUserControl();
            //CategorySer s = new CategorySer();


            //if(category_ID != 0)
            //    cuc.ProjectName = s.GetCategoryName(category_ID, LogIn.user_ID);
            //else if(CategoryName != "")
            //{
            //    category_ID = s.GetCategoryID(CategoryName, LogIn.user_ID);
            //    cuc.ProjectName = CategoryName;
            //}


            ////int cat_ID = s.GetCategoryID("Inbox");
            //TaskListShow(cuc.Flow, category_ID);
            //panel4.Controls.Add(cuc);


            //After

            try
            {
                if (checkFormLoadFirstTime == false)
                {
                    CategoryListShow();
                    CategorySer s = new CategorySer();
                    int catID = s.GetCategoryID("Inbox", LogIn.user_ID);

                    TaskSer taskS = new TaskSer();
                    List<Tasks> taskList = taskS.GetAll(catID);
                    UserControlForOnlyTestPurpose.uC.Project_Name = "Inbox";
                    UserControlForOnlyTestPurpose.uC.LoadTaskList(taskList);

                    checkFormLoadFirstTime = true;
                }
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
            }




        }

        private int GetCatID(string catName)
        {
            CategorySer cs = new CategorySer();
            return cs.GetCategoryID(catName, LogIn.user_ID);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Focus();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnToday_Click(object sender, EventArgs e)
        {

            //Before


            //flowLayoutPanel1Today.Controls.Clear();
            //CategorySer cs = new CategorySer();
            //pnlContentChangeToday.BringToFront();
            //int catID = cs.GetCategoryID("Today");
            //TaskListShow(flowLayoutPanel1Today, catID);


            //if (!(flowLayoutPanel2.VerticalScroll.Value == 0 && scrollPos != 0))
            //    scrollPos = flowLayoutPanel2.VerticalScroll.Value;

            //only THis Open

            //HomePage2.home2.Close();
            //HomePage2.home2 = new HomePage2("Today");
            //HomePage2.home2.Show();

            //only THis Open

            //HomePage2.home2.ContentFormLoad("Today");


            //HomePage2.home2.flowLayoutPanel2.VerticalScroll.Value = scrollPos;





            //AFter

            try
            {
                //CategoryListShow();
                CategorySer s = new CategorySer();
                int catID = s.GetCategoryID("Today", LogIn.user_ID);

                TaskSer taskS = new TaskSer();
                List<Tasks> taskList = taskS.GetAll(catID);
                UserControlForOnlyTestPurpose.uC.Project_Name = "Today";
                UserControlForOnlyTestPurpose.uC.LoadTaskList(taskList);
            }

            
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message + "Hello World");
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //if (count % 2 == 0)
            //    pnlSetting.Visible = true;
            //else
            //    pnlSetting.Visible = false;
            //count++;

        }

        private void btnNext7Day_Click(object sender, EventArgs e)
        {
            //After

            try
            {
                //CategoryListShow();
                CategorySer s = new CategorySer();
                int catID = s.GetCategoryID("Next 7 Day", LogIn.user_ID);

                TaskSer taskS = new TaskSer();
                List<Tasks> taskList = taskS.GetAll(catID);
                UserControlForOnlyTestPurpose.uC.Project_Name = "Next 7 Day";

                UserControlForOnlyTestPurpose.uC.LoadTaskList(taskList);
            }
            catch(Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
            

        }



        //After



        public void ForProjectUserControl(string projectName)
        {
            try
            {
                CategorySer s = new CategorySer();
                int catID = s.GetCategoryID(projectName, LogIn.user_ID);

                TaskSer taskS = new TaskSer();
                List<Tasks> taskList = taskS.GetAll(catID);
                userControlForOnlyTestPurpose2.Project_Name = projectName;

                userControlForOnlyTestPurpose2.LoadTaskList(taskList);
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
        }

        private void pnlUp_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void pnlUp_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void pnlUp_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SearchForm sF = new SearchForm();
            sF.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if(count%2 == 0)
                panel1.Visible = true;
            else
                panel1.Visible = false;
            count++;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInfoForm uIF = new UserInfoForm();
            uIF.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GraphForm gF = new GraphForm();
            gF.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            home2.WindowState = FormWindowState.Minimized;
        }
    }
}
