using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Services;
using System.IO;
using ExcelDataReader;
using OfficeOpenXml;

namespace Task_Manager
{
    public partial class UserControlForOnlyTestPurpose : UserControl
    {
        int cat_ID;
        public static UserControlForOnlyTestPurpose uC;
        public UserControlForOnlyTestPurpose()
        {
            uC = this;
            InitializeComponent();
            Bitmap img = new Bitmap("C:\\Users\\sajib\\source\\repos\\Task Manager\\image\\layers.png");
            pictureBox2Today.Image = img;
        }
        string _name = "Inbox";
        static int count = 0;
        public string Project_Name
        {
            get { return _name; }
            set { _name = value; label1.Text = _name; cat_ID = GetCategoryID(); }
        }

        public void LoadTaskList(List<Tasks> taskList)
        {
            
            flowLayoutPanel1Today.Controls.Clear();
            for (int i = 0; i < taskList.Count; i++)
            {
                AddTaskInfo pUC = new AddTaskInfo();
                pUC.Tittle = taskList[i].Tittle;
                if (!(taskList[i].Date.Equals("")))
                    pUC.Date = Convert.ToDateTime(taskList[i].Date).ToLongDateString();
                
                pUC.Task_ID = taskList[i].Task_ID;
                flowLayoutPanel1Today.Controls.Add(pUC);
            }
        }

        public void LoadTaskList()
        {
            cat_ID = GetCategoryID();
            TaskSer ts = new TaskSer();
            List<Tasks> taskList = ts.GetAll(cat_ID);
            flowLayoutPanel1Today.Controls.Clear();
            for (int i = 0; i < taskList.Count; i++)
            {
                AddTaskInfo pUC = new AddTaskInfo();
                pUC.Tittle = taskList[i].Tittle;
                if (!(taskList[i].Date.Equals("")))
                    pUC.Date = Convert.ToDateTime(taskList[i].Date).ToLongDateString();
                pUC.Task_ID = taskList[i].Task_ID;
                flowLayoutPanel1Today.Controls.Add(pUC);
            }
        }


        private void pictureBox2Today_Click(object sender, EventArgs e)
        {
            if (count % 2 == 0)
                pnlSetting.Visible = true;
            else
                pnlSetting.Visible = false;
            count++;
        }


        private int GetCategoryID()
        {
            CategorySer cg = new CategorySer();
            return cg.GetCategoryID(Project_Name, LogIn.user_ID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaskSer cs = new TaskSer();
            List<Tasks> tk = cs.GetAllSortByDate(cat_ID);

            LoadTaskList(tk);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            TaskSer cs = new TaskSer();
            List<Tasks> tk = cs.GetAllSortByPriority(cat_ID);

            LoadTaskList(tk);
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (!button5.Text.Equals("Show Uncompleted Task"))
            {
                button5.Text = "Show Uncompleted Task";
                flowLayoutPanel1Today.Controls.Clear();

                TaskSer cs = new TaskSer();
                List<Tasks> tk = cs.GetAllCompleteOrNotTask(1, cat_ID);

                for (int i = 0; i < tk.Count; i++)
                {
                    AddTaskInfo ad = new AddTaskInfo();
                    ad.Tittle = tk[i].Tittle;
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
                
                
                TaskSer cs = new TaskSer();
                List<Tasks> tk = cs.GetAll(cat_ID);

                LoadTaskList(tk);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            TaskSer cs = new TaskSer();
            List<Tasks> tk= cs.GetAllSortByTittle(cat_ID);
            LoadTaskList(tk);
        }



        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog fb = new OpenFileDialog();
            fb.Filter = "Excel Office | *.xls; *.xlsx";

            if (fb.ShowDialog() == DialogResult.OK)
            {
                FileStream strem = new FileStream(fb.FileName, FileMode.Open, FileAccess.Read);
                IExcelDataReader exReader = ExcelReaderFactory.CreateReader(strem);
                DataSet ds = exReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                
                List<Tasks> tk = new List<Tasks>();
                Tasks t;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    t = new Tasks();
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        //if (j == 0)
                        //    t.Task_ID = Convert.ToInt32(ds.Tables[0].Rows[i][j].ToString());
                        if (j == 0)
                            t.Tittle = ds.Tables[0].Rows[i][j].ToString();
                        //else if (j == 2)
                        //    t.Date = ds.Tables[0].Rows[i][j].ToString();
                        else if (j == 1)
                            t.Time = ds.Tables[0].Rows[i][j].ToString();
                        //else if (j == 4)
                        //    t.RepeatDateTask_ID = ds.Tables[0].Rows[i][j].ToString();
                        else if (j == 2)
                            t.Description = ds.Tables[0].Rows[i][j].ToString();
                        else if (j == 3)
                            t.Priority = Convert.ToInt32(ds.Tables[0].Rows[i][j].ToString());
                        //else if (j == 7)
                        //    t.Category_ID = cat_ID;
                        //else
                        //    t.Task_Complete = Convert.ToInt32(ds.Tables[0].Rows[i][j].ToString());
                    }
                    t.RepeatDateTask_ID = System.Guid.NewGuid().ToString();
                    t.Category_ID = cat_ID;
                    tk.Add(t);
                }
                exReader.Dispose();
                strem.Dispose();
                ds.Dispose();

                TaskSer tkSer = new TaskSer();

                for (int i = 0; i < tk.Count; i++)
                {
                    tkSer.InsertFormImportFile(tk[i]);
                }

                MessageBox.Show("File Is Imported");

                LoadTaskList();


            }
        }




        private void button6_Click(object sender, EventArgs e)
        {
            TaskSer tk = new TaskSer();
            List<Tasks> taskList = tk.GetAll(cat_ID);


            string spreadSheetPath = "E:\\SQL SERVER\\sajib.xlsx";
            File.Delete(spreadSheetPath);
            FileInfo spreadSheetInfo = new FileInfo(spreadSheetPath);

            ExcelPackage pck = new ExcelPackage(spreadSheetInfo);

            var workSheet = pck.Workbook.Worksheets.Add("My First");
            //workSheet.Cells["A1"].Value = "Task_ID";
            workSheet.Cells["A1"].Value = "Task_Title";
            //workSheet.Cells["C1"].Value = "Task_Date";
            workSheet.Cells["B1"].Value = "Task_Time";
            //workSheet.Cells["E1"].Value = "Task_Repeat_Date_ID";
            workSheet.Cells["C1"].Value = "Task_Description";
            workSheet.Cells["D1"].Value = "Task_Priority";
            //workSheet.Cells["H1"].Value = "Category_ID";
            //workSheet.Cells["I1"].Value = "Task_Complete";

            int currentRow = 2;
            foreach (var tasklist in taskList)
            {
                //workSheet.Cells["A" + currentRow.ToString()].Value = tasklist.Task_ID;
                workSheet.Cells["A" + currentRow.ToString()].Value = tasklist.Tittle;
                //workSheet.Cells["C" + currentRow.ToString()].Value = Convert.ToDateTime(tasklist.Date).ToShortDateString();
                workSheet.Cells["B" + currentRow.ToString()].Value = tasklist.Time.ToString();
                //workSheet.Cells["E" + currentRow.ToString()].Value = tasklist.RepeatDateTask_ID;

                workSheet.Cells["C" + currentRow.ToString()].Value = tasklist.Description;
                workSheet.Cells["D" + currentRow.ToString()].Value = tasklist.Priority;
                //workSheet.Cells["H" + currentRow.ToString()].Value = tasklist.Category_ID;
                //workSheet.Cells["I" + currentRow.ToString()].Value = tasklist.Task_Complete;

                currentRow++;
            }

            pck.Save();
            pck.Dispose();
            MessageBox.Show("File Is Exported");
        }



        private void button8_Click(object sender, EventArgs e)
        {
            ShareCategroyTasks sct = new ShareCategroyTasks(cat_ID);
            sct.Show();
        }
    }
}
