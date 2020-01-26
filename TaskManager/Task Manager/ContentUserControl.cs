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
using Entity;
using Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;
using ExcelDataReader;

namespace Task_Manager
{
    public partial class ContentUserControl : UserControl
    {
        static int count = 0;
        public static ContentUserControl conUserCon;


        

        public ContentUserControl()
        {
            conUserCon = this;
            InitializeComponent();
        }
        string _projectName;
        //FlowLayoutPanel _flow;



        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; label1.Text = _projectName; }
        }

        public FlowLayoutPanel Flow
        {
            get 
            {
                //flowLayoutPanel1Today.Controls.Clear();
                return flowLayoutPanel1Today; 
            }
            ///set { _flow = value; flowLayoutPanel1Today = _flow; }
            //set { _flow = value; flowLayoutPanel1Today = _flow; }
        }

        private void pictureBox2Today_Click(object sender, EventArgs e)
        {
            if (count % 2 == 0)
                pnlSetting.Visible = true;
            else
                pnlSetting.Visible = false;
            count++;
        }
        public void RefreshContent()
        {
            flowLayoutPanel1Today.Controls.Clear();
            List<Tasks> tk;
            TaskSer cs = new TaskSer();
            CategorySer cg = new CategorySer();
            int cat_Id = cg.GetCategoryID(ProjectName, LogIn.user_ID);
            //MessageBox.Show(ProjectName);
            //MessageBox.Show(cat_Id.ToString());
            cg = new CategorySer();
            tk = cs.GetAllSortByDate(cat_Id);

            for (int i = 0; i < tk.Count; i++)
            {
                AddTaskInfo ad = new AddTaskInfo();
                ad.Tittle = tk[i].Tittle;
                ad.Date = Convert.ToDateTime(tk[i].Date).ToLongDateString();
                ad.Task_ID = tk[i].Task_ID;
                flowLayoutPanel1Today.Controls.Add(ad);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!button5.Text.Equals("Show Uncompleted Task"))
            {
                button5.Text = "Show Uncompleted Task";
                flowLayoutPanel1Today.Controls.Clear();
                List<Tasks> tk;
                TaskSer cs = new TaskSer();

                CategorySer cg = new CategorySer();
                int cat_Id = cg.GetCategoryID(ProjectName, LogIn.user_ID);
                //tk = cs.GetAll(cat_Id);
                cg = new CategorySer();
                tk = cs.GetAllCompleteOrNotTask(1, cat_Id);

                for (int i = 0; i < tk.Count; i++)
                {
                    AddTaskInfo ad = new AddTaskInfo();
                    ad.Tittle = tk[i].Tittle;
                    //DateTime dt = DateTime.Parse(tk[i].Date, "dddd, dd MMMM yyyy");
                    ad.Date = Convert.ToDateTime(tk[i].Date).ToLongDateString();
                    ad.Task_ID = tk[i].Task_ID;
                    Bitmap img = new Bitmap("C:\\Users\\sajib\\source\\repos\\Task Manager\\image\\checkmark.png");
                    ad.Icon = img;
                    flowLayoutPanel1Today.Controls.Add(ad);
                }
            }
            else
            {
                button5.Text = "Show Completed Task";
                flowLayoutPanel1Today.Controls.Clear();
                List<Tasks> tk;
                TaskSer cs = new TaskSer();
                CategorySer cg = new CategorySer();
                int cat_Id= cg.GetCategoryID(ProjectName, LogIn.user_ID);
                cg = new CategorySer();
                tk = cs.GetAll(cat_Id);

                for (int i = 0; i < tk.Count; i++)
                {
                    AddTaskInfo ad = new AddTaskInfo();
                    ad.Tittle = tk[i].Tittle;
                    ad.Date = Convert.ToDateTime(tk[i].Date).ToLongTimeString();
                    ad.Task_ID = tk[i].Task_ID;
                    flowLayoutPanel1Today.Controls.Add(ad);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1Today.Controls.Clear();
            List<Tasks> tk;
            TaskSer cs = new TaskSer();
            CategorySer cg = new CategorySer();
            int cat_Id = cg.GetCategoryID(ProjectName, LogIn.user_ID);
            //MessageBox.Show(ProjectName);
            //MessageBox.Show(cat_Id.ToString());
            cg = new CategorySer();
            tk = cs.GetAllSortByDate(cat_Id);

            for (int i = 0; i < tk.Count; i++)
            {
                AddTaskInfo ad = new AddTaskInfo();
                ad.Tittle = tk[i].Tittle;
                ad.Date = Convert.ToDateTime(tk[i].Date).ToLongDateString();
                ad.Task_ID = tk[i].Task_ID;
                flowLayoutPanel1Today.Controls.Add(ad);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1Today.Controls.Clear();
            List<Tasks> tk;
            TaskSer cs = new TaskSer();
            CategorySer cg = new CategorySer();
            int cat_Id = cg.GetCategoryID(ProjectName, LogIn.user_ID);
            //MessageBox.Show(ProjectName);
            //MessageBox.Show(cat_Id.ToString());
            cg = new CategorySer();
            tk = cs.GetAllSortByPriority(cat_Id);

            for (int i = 0; i < tk.Count; i++)
            {
                AddTaskInfo ad = new AddTaskInfo();
                ad.Tittle = tk[i].Tittle;
                ad.Date = Convert.ToDateTime(tk[i].Date).ToLongDateString();
                ad.Task_ID = tk[i].Task_ID;
                flowLayoutPanel1Today.Controls.Add(ad);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1Today.Controls.Clear();
            List<Tasks> tk;
            TaskSer cs = new TaskSer();
            CategorySer cg = new CategorySer();
            int cat_Id = cg.GetCategoryID(ProjectName, LogIn.user_ID);
            //MessageBox.Show(ProjectName);
            //MessageBox.Show(cat_Id.ToString());
            cg = new CategorySer();
            tk = cs.GetAllSortByTittle(cat_Id);

            for (int i = 0; i < tk.Count; i++)
            {
                AddTaskInfo ad = new AddTaskInfo();
                ad.Tittle = tk[i].Tittle;
                ad.Date = Convert.ToDateTime(tk[i].Date).ToLongDateString();
                ad.Task_ID = tk[i].Task_ID;
                flowLayoutPanel1Today.Controls.Add(ad);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CategorySer cg = new CategorySer();
            int cat_Id = cg.GetCategoryID(ProjectName, LogIn.user_ID);
            OpenFileDialog fb = new OpenFileDialog();
            fb.Filter = "Excel Office | *.xls; *.xlsx";
            
            if (fb.ShowDialog() == DialogResult.OK)
            {
                FileStream strem = new FileStream(fb.FileName, FileMode.Open, FileAccess.Read);
                IExcelDataReader exReader = ExcelReaderFactory.CreateReader(strem);
                DataSet ds = exReader.AsDataSet(new ExcelDataSetConfiguration() 
                {
                    ConfigureDataTable=(_)=> new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                TaskSer tkSer = new TaskSer();
                List<Tasks> tk = new List<Tasks>();
                Tasks t;
                for (int i=0; i<ds.Tables[0].Rows.Count; i++)
                {
                    t = new Tasks();
                    for (int j=0; j<ds.Tables[0].Columns.Count; j++)
                    {
                        if(j == 0)
                            t.Task_ID = Convert.ToInt32(ds.Tables[0].Rows[i][j].ToString());
                        else if(j == 1)
                            t.Tittle = ds.Tables[0].Rows[i][j].ToString();
                        else if(j == 2)
                            t.Date = ds.Tables[0].Rows[i][j].ToString();
                        else if (j == 3)
                            t.Time = ds.Tables[0].Rows[i][j].ToString();
                        else if (j == 4)
                            t.RepeatDateTask_ID = ds.Tables[0].Rows[i][j].ToString();
                        else if (j == 5)
                            t.Description = ds.Tables[0].Rows[i][j].ToString();
                        else if (j == 6)
                            t.Priority = Convert.ToInt32(ds.Tables[0].Rows[i][j].ToString());
                        else if (j == 7)
                            t.Category_ID = cat_Id;
                        else
                            t.Task_Complete = Convert.ToInt32(ds.Tables[0].Rows[i][j].ToString());
                    }
                    tk.Add(t);
                }
                exReader.Close();
                strem.Close();

                for (int i = 0; i < tk.Count; i++)
                {
                    tkSer.Insert(tk[i]);
                }

                MessageBox.Show("File Is Imported");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CategorySer cg = new CategorySer();
            int cat_Id = cg.GetCategoryID(ProjectName,LogIn.user_ID);
            TaskSer tk = new TaskSer();
            List<Tasks> taskList = tk.GetAll(cat_Id);


            string spreadSheetPath = "E:\\SQL SERVER\\sajib.xlsx";
            File.Delete(spreadSheetPath);
            FileInfo spreadSheetInfo = new FileInfo(spreadSheetPath);

            ExcelPackage pck = new ExcelPackage(spreadSheetInfo);

            var workSheet = pck.Workbook.Worksheets.Add("My First");
            workSheet.Cells["A1"].Value = "Task_ID";
            workSheet.Cells["B1"].Value = "Task_Title";
            workSheet.Cells["C1"].Value = "Task_Date";
            workSheet.Cells["D1"].Value = "Task_Time";
            workSheet.Cells["E1"].Value = "Task_Repeat_Date_ID";
            workSheet.Cells["F1"].Value = "Task_Description";
            workSheet.Cells["G1"].Value = "Task_Priority";
            workSheet.Cells["H1"].Value = "Category_ID";
            workSheet.Cells["I1"].Value = "Task_Complete";

            int currentRow = 2;
            foreach (var tasklist in taskList)
            {
                workSheet.Cells["A" + currentRow.ToString()].Value = tasklist.Task_ID;
                workSheet.Cells["B" + currentRow.ToString()].Value = tasklist.Tittle;
                workSheet.Cells["C" + currentRow.ToString()].Value = Convert.ToDateTime(tasklist.Date).ToShortDateString();
                workSheet.Cells["D" + currentRow.ToString()].Value = tasklist.Time.ToString();
                workSheet.Cells["E" + currentRow.ToString()].Value = tasklist.RepeatDateTask_ID;

                workSheet.Cells["F" + currentRow.ToString()].Value = tasklist.Description;
                workSheet.Cells["G" + currentRow.ToString()].Value = tasklist.Priority;
                workSheet.Cells["H" + currentRow.ToString()].Value = tasklist.Category_ID;
                workSheet.Cells["I" + currentRow.ToString()].Value = tasklist.Task_Complete;

                currentRow++;
            }

            pck.Save();
            pck.Dispose();
            MessageBox.Show("File Is Exported");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CategorySer cg = new CategorySer();
            int cat_Id = cg.GetCategoryID(ProjectName, LogIn.user_ID);
            ShareCategroyTasks sct = new ShareCategroyTasks(cat_Id);
            sct.Show();
        }
    }
}
