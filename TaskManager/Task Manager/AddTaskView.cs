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
    public partial class AddTaskView : Form
    {
        public static AddTaskView addTaskView;
        CategorySer cat;
        List<Category> ct;
        Tasks obj;

        int mov;
        int movX;
        int movY;


        public AddTaskView()
        {
            addTaskView = this;
            InitializeComponent();
            cat = new CategorySer();
        }

        public void LoadDataInfoOfTask(Tasks obj)
        {
            button1.Text = "Update";

            this.obj = obj;
            textBox1.Text = obj.Tittle;
            textBox2.Text = obj.Description;
            dateTimePicker2.Value = Convert.ToDateTime(obj.Date);
            dateTimePicker1.Value = Convert.ToDateTime(obj.Time);

            CategorySer cS = new CategorySer();

            cBCategory.Text = cS.GetCategoryName(obj.Category_ID, LogIn.user_ID);

            if (obj.Priority == 1)
                cBPriority.Text = "Low";
            else if (obj.Priority == 2)
                cBPriority.Text = "Medium";
            else
                cBPriority.Text = "High";

            if (obj.RepeatName == "")
                cBRepeat.Text = "Doesn't Repeat";
            else
                cBRepeat.Text = obj.RepeatName;

            for (int i = 0; i < obj.Notify_Time_List.Count; i++)
            {
                cBSelectedReminders.Items.Add(obj.Notify_Time_List[i].NotifyTimeBeforeString);
            }


        }





        public void AddCustomNotification(int val, string time, int notifyVia)
        {
            string addCustomNofication;
            if (notifyVia == 1)
            {
                addCustomNofication = val.ToString() + time + " - NO";
                cBSelectedReminders.Items.Add(addCustomNofication);
            }
            else if(notifyVia == 2)
            {
                addCustomNofication = val.ToString() + time + " - EM";
                cBSelectedReminders.Items.Add(addCustomNofication);
            }
            else
            {
                addCustomNofication = val.ToString() + time + " - SM";
                cBSelectedReminders.Items.Add(addCustomNofication);
            }
            
        }
        public void AddCustomRepeatedDate(int val, string time, int repeat)
        {
            if(repeat != 0)
            {
                string rep = "Repeats every " + val.ToString() +" "+time+"; For "+repeat.ToString()+" times";
                MessageBox.Show(rep);
                cBRepeat.Items.Add(rep);
                cBRepeat.Text = rep;
            }
            else
            {
                string rep = "Repeats every " + val.ToString() + " "+time;
                MessageBox.Show(rep);
                cBRepeat.Items.Add(rep);
                cBRepeat.Text = rep;
            }
            
        }
        public void AddCustomRepeatedDate(int val, string time, DateTime repeat)
        {
            string rep = "Repeats every " + val.ToString() +" "+time +"; Untill "+repeat.ToShortDateString();
            MessageBox.Show(rep);
            cBRepeat.Items.Add(rep);
            cBRepeat.Text = rep;
        }

        public void AddCustomRepeatedDate(int val, string time, List<string> weekName, int repeat)
        {

            if (repeat != 0)
            {
                string rep = "Repeats every " + val.ToString() +" "+ time + " on ";
                for (int i = 0; i < weekName.Count; i++)
                {
                    rep += weekName[i];
                    if (i != weekName.Count - 1)
                        rep += ", ";
                }
                rep += "; For " + repeat.ToString() + " times";
                MessageBox.Show(rep);
                cBRepeat.Items.Add(rep);
                cBRepeat.Text = rep;
            }
            else
            {
                string rep = "Repeats every " + val.ToString() + " " + time + " on ";
                for (int i = 0; i < weekName.Count; i++)
                {
                    rep += weekName[i];
                    if (i != weekName.Count - 1)
                        rep += ", ";
                }
                //rep += "For " + repeat.ToString() + " times";
                MessageBox.Show(rep);
                cBRepeat.Items.Add(rep);
                cBRepeat.Text = rep;
            }
        }

        public void AddCustomRepeatedDate(int val, string time, List<string> weekName, DateTime repeat)
        {
            string rep = "Repeats every " + val.ToString() + " " + time + " on ";
            for (int i = 0; i < weekName.Count; i++)
            {
                rep += weekName[i];
                if (i != weekName.Count - 1)
                    rep += ", ";
            }
            rep += "; Untill " + repeat.ToShortDateString();
            MessageBox.Show(rep);
            cBRepeat.Items.Add(rep);
            cBRepeat.Text = rep;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTaskView_Load(object sender, EventArgs e)
        {
            //ct = new List<Category>();
            ct = cat.GetAll(LogIn.user_ID);
            for (int i = 0; i < ct.Count; i++)
            {
                cBCategory.Items.Add(ct[i].Name);
            }
        }


        private void pBoxAddTaskView_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (cBSelectReminder.SelectedIndex < 0)
                MessageBox.Show("Select Reminder");
            else
            {
                for(int i=0; i<cBSelectedReminders.Items.Count; i++)
                {
                    if (cBSelectedReminders.Items[i].ToString().Equals(cBSelectReminder.SelectedItem))
                    {
                        MessageBox.Show("Already Added!!");
                        flag = false;
                    }
                        
                }
                if(flag)
                {
                    if(!(cBSelectReminder.SelectedItem.ToString().Equals("Custom")))
                        cBSelectedReminders.Items.Add(cBSelectReminder.SelectedItem);
                }
                    
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cBSelectedReminders.SelectedIndex < 0)
                MessageBox.Show("Select Reminder");
            else
            {
                cBSelectedReminders.Items.Remove(cBSelectedReminders.SelectedItem);
            }
        }

        private int Priority(string str)
        {
            if (str.Equals("High"))
                return 1;
            else if (str.Equals("Medium"))
                return 2;
            else
                return 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(button1.Text == "Update")
            {
                AddTaskForUpdateInDatabase();
            }
            else
            {
                AddTaskInDatabase();
            }

        }



        public void AddTaskForUpdateInDatabase()
        {
            bool checkRepeatIsChange = false;



            TaskSer taskService = new TaskSer();
            Tasks ts = new Tasks();
            ts.Task_ID = obj.Task_ID;
            ts.Tittle = textBox1.Text;
            ts.Description = textBox2.Text;
            ts.Date = dateTimePicker2.Value.ToShortDateString();
            ts.Time = dateTimePicker1.Value.ToShortTimeString();

            CategorySer cS = new CategorySer();
            int cat_ID;
            if (cBCategory.SelectedIndex < 0)
                cat_ID = cS.GetCategoryID("Inbox", LogIn.user_ID);
            else
                cat_ID = cS.GetCategoryID(cBCategory.SelectedItem.ToString(), LogIn.user_ID);

            ts.Category_ID = cat_ID;

            int prio;
            if (cBPriority.SelectedIndex < 0)
                prio = 1;
            else
            {
                if (cBPriority.SelectedItem.ToString().Equals("High"))
                    prio = 3;
                else if (cBPriority.SelectedItem.ToString().Equals("Medium"))
                    prio = 2;
                else
                    prio = 1;
            }

            ts.Priority = prio;

            List<BeforeNotificationTime> notificationTimeList = new List<BeforeNotificationTime>();

            if (cBSelectedReminders.Items.Count == 0)
            {
                //MessageBox.Show(cBSelectedReminders.Items.Count.ToString());
                BeforeNotificationTime notifyTime = new BeforeNotificationTime();
                notifyTime.Date = dateTimePicker2.Value.ToShortDateString();
                notifyTime.Time = dateTimePicker1.Value.ToShortTimeString();
                notificationTimeList.Add(notifyTime);
            }
            else
            {


                //MessageBox.Show("Inside The Else Part");
                //5 minutes before
                //10 minutes before
                //15 minutes before
                //30 minutes before
                //1 hour before
                for (int i = 0; i < cBSelectedReminders.Items.Count; i++)
                {
                    BeforeNotificationTime notifyTime = new BeforeNotificationTime();
                    string time;
                    time = cBSelectedReminders.Items[i].ToString();
                    string an = "";
                    for (int k = 0; k < time.Length; k++)
                    {
                        if (time[k] == ' ')
                            break;
                        an += (time[k].ToString());
                    }

                    int timeValue = Convert.ToInt32(an);


                    //MessageBox.Show(timeValue.ToString());

                    if (cBSelectedReminders.Items[i].ToString().Contains("minutes before - NO"))
                    {

                        //MessageBox.Show("Inside Minutes Part");
                        notifyTime.NotifyTimeBeforeString = cBSelectedReminders.Items[i].ToString();

                        notifyTime.Date = dateTimePicker2.Value.ToShortDateString();
                        DateTime tm = dateTimePicker1.Value;
                        DateTime tm2 = tm.AddMinutes(timeValue);
                        TimeSpan t = tm2 - tm;
                        tm = tm - t;
                        notifyTime.Time = tm.ToShortTimeString();


                        //MessageBox.Show(tm.ToShortTimeString());


                        if (cBSelectedReminders.Items.ToString().Contains("EM"))
                            notifyTime.Notify_Via = 2;
                        if (cBSelectedReminders.Items.ToString().Contains("SM"))
                            notifyTime.Notify_Via = 3;
                        else
                            notifyTime.Notify_Via = 1;



                        notificationTimeList.Add(notifyTime);

                    }
                    else if (cBSelectedReminders.Items[i].ToString().Contains("hours before - NO"))
                    {


                        //MessageBox.Show("Inside Hours Part");
                        notifyTime.NotifyTimeBeforeString = cBSelectedReminders.Items[i].ToString();

                        notifyTime.Date = dateTimePicker2.Value.ToShortDateString();
                        DateTime tm = dateTimePicker1.Value;
                        DateTime tm2 = tm.AddHours(timeValue);
                        TimeSpan t = tm2 - tm;
                        tm = tm - t;
                        notifyTime.Time = tm.ToShortTimeString();


                        if (cBSelectedReminders.Items.ToString().Contains("EM"))
                            notifyTime.Notify_Via = 2;
                        if (cBSelectedReminders.Items.ToString().Contains("SM"))
                            notifyTime.Notify_Via = 3;
                        else
                            notifyTime.Notify_Via = 1;


                        notificationTimeList.Add(notifyTime);
                    }
                    else if (cBSelectedReminders.Items[i].ToString().Contains("days before - NO"))
                    {

                        //MessageBox.Show("Inside Days Part");
                        notifyTime.NotifyTimeBeforeString = cBSelectedReminders.Items[i].ToString();

                        DateTime tm = dateTimePicker1.Value;
                        DateTime tm2 = tm.AddDays(timeValue);
                        TimeSpan t = tm2 - tm;
                        tm = tm - t;
                        notifyTime.Date = tm.ToShortDateString();
                        notifyTime.Time = dateTimePicker1.Value.ToShortTimeString();


                        if (cBSelectedReminders.Items.ToString().Contains("EM"))
                            notifyTime.Notify_Via = 2;
                        if (cBSelectedReminders.Items.ToString().Contains("SM"))
                            notifyTime.Notify_Via = 3;
                        else
                            notifyTime.Notify_Via = 1;


                        notificationTimeList.Add(notifyTime);
                    }
                    else
                    {
                        //MessageBox.Show("Inside Weeks Part");
                        notifyTime.NotifyTimeBeforeString = cBSelectedReminders.Items[i].ToString();

                        DateTime tm = dateTimePicker1.Value;
                        DateTime tm2 = tm.AddDays(timeValue * 7);
                        TimeSpan t = tm2 - tm;
                        tm = tm - t;
                        notifyTime.Date = tm.ToShortDateString();
                        notifyTime.Time = dateTimePicker1.Value.ToShortTimeString();


                        if (cBSelectedReminders.Items.ToString().Contains("EM"))
                            notifyTime.Notify_Via = 2;
                        if (cBSelectedReminders.Items.ToString().Contains("SM"))
                            notifyTime.Notify_Via = 3;
                        else
                            notifyTime.Notify_Via = 1;



                        notificationTimeList.Add(notifyTime);
                    }
                }


            }


            ts.Notify_Time_List = notificationTimeList;
            List<string> repeateDateList = new List<string>(100);

            if (cBRepeat.Text.Equals(obj.RepeatName) || cBRepeat.SelectedIndex < 0)
            {
                ts.Repeat_Date_List = obj.Repeat_Date_List;
            }
            else
            {
                if (MessageBox.Show("Are you update All Task Which is follwing this task????", "Hello!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    checkRepeatIsChange = true;


                    TaskSer taskS = new TaskSer();
                    taskS.DeleteByRepeatID(obj.RepeatDateTask_ID);


                    ts.RepeatDateTask_ID = System.Guid.NewGuid().ToString();
                    if (cBRepeat.SelectedItem.ToString().Equals("Every day"))
                    {
                        DateTime dt = DateTime.Now;
                        for (int i = 0; i < repeateDateList.Capacity; i++)
                        {
                            repeateDateList.Add(dt.ToShortDateString());
                            dt = dt.AddDays(1);
                        }
                    }
                    else if (cBRepeat.SelectedItem.ToString().Equals("Every week"))
                    {
                        DateTime dt = DateTime.Now;
                        for (int i = 0; i < repeateDateList.Capacity; i++)
                        {
                            repeateDateList.Add(dt.ToShortDateString());
                            dt = dt.AddDays(7);
                        }
                    }
                    else if (cBRepeat.SelectedItem.ToString().Equals("Every month"))
                    {
                        DateTime dt = DateTime.Now;
                        for (int i = 0; i < repeateDateList.Capacity; i++)
                        {
                            repeateDateList.Add(dt.ToShortDateString());
                            dt = dt.AddMonths(1);
                        }
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        for (int i = 0; i < repeateDateList.Capacity; i++)
                        {
                            repeateDateList.Add(dt.ToShortDateString());
                            dt = dt.AddYears(1);
                        }
                    }




                }
                else
                {
                    cBRepeat.Text = obj.RepeatName;
                }
            }





            if (checkRepeatIsChange)
            {
                ts.Repeat_Date_List = repeateDateList;
                TaskSer tSer = new TaskSer();
                tSer.Insert(ts);
            }
            else
            {
                TaskSer tSer = new TaskSer();
                tSer.Update(ts);
            }

            this.Close();

            MessageBox.Show("Task Is Updated");
            UserControlForOnlyTestPurpose.uC.LoadTaskList();

        }





        private void AddTaskInDatabase()
        {
            List<string> repeateDateList = new List<string>(100);
            List<BeforeNotificationTime> notificationTimeList = new List<BeforeNotificationTime>();
            CategorySer cSer = new CategorySer();
            if (textBox1.Text != null)
            {
                Tasks ts = new Tasks();
                ts.Tittle = textBox1.Text;

                if (textBox2.Text != null)
                    ts.Description = textBox2.Text;

                ts.Date = dateTimePicker2.Value.ToShortDateString();
                ts.Time = dateTimePicker1.Value.ToString("hh:mm tt");

                if (cBCategory.SelectedIndex < 0)
                    ts.Category_ID = cSer.GetCategoryID("Inbox", LogIn.user_ID);
                else
                    ts.Category_ID = cSer.GetCategoryID(cBCategory.SelectedItem.ToString(), LogIn.user_ID);


                if (cBPriority.SelectedIndex < 0)
                    ts.Priority = 1;
                else
                {
                    if (cBPriority.SelectedItem.ToString().Equals("High"))
                        ts.Priority = 3;
                    else if (cBPriority.SelectedItem.ToString().Equals("Medium"))
                        ts.Priority = 2;
                    else
                        ts.Priority = 1;
                }


                if (cBRepeat.SelectedIndex < 0)
                    ts.RepeatDateTask_ID = System.Guid.NewGuid().ToString();
                else
                {
                    ts.RepeatDateTask_ID = System.Guid.NewGuid().ToString();
                    if (cBRepeat.SelectedItem.ToString().Equals("Every day"))
                    {
                        DateTime dt = DateTime.Now;
                        for (int i = 0; i < repeateDateList.Capacity; i++)
                        {
                            repeateDateList.Add(dt.ToShortDateString());
                            dt = dt.AddDays(1);
                        }
                    }
                    else if (cBRepeat.SelectedItem.ToString().Equals("Every week"))
                    {
                        DateTime dt = DateTime.Now;
                        for (int i = 0; i < repeateDateList.Capacity; i++)
                        {
                            repeateDateList.Add(dt.ToShortDateString());
                            dt = dt.AddDays(7);
                        }
                    }
                    else if (cBRepeat.SelectedItem.ToString().Equals("Every month"))
                    {
                        DateTime dt = DateTime.Now;
                        for (int i = 0; i < repeateDateList.Capacity; i++)
                        {
                            repeateDateList.Add(dt.ToShortDateString());
                            dt = dt.AddMonths(1);
                        }
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        for (int i = 0; i < repeateDateList.Capacity; i++)
                        {
                            repeateDateList.Add(dt.ToShortDateString());
                            dt = dt.AddYears(1);
                        }
                    }

                }



                if (cBSelectedReminders.Items.Count == 0)
                {
                    //MessageBox.Show(cBSelectedReminders.Items.Count.ToString());
                    BeforeNotificationTime notifyTime = new BeforeNotificationTime();
                    notifyTime.Date = dateTimePicker2.Value.ToShortDateString();
                    notifyTime.Time = dateTimePicker1.Value.ToShortTimeString();
                    notificationTimeList.Add(notifyTime);
                }
                else
                {


                    //MessageBox.Show("Inside The Else Part");
                    //5 minutes before
                    //10 minutes before
                    //15 minutes before
                    //30 minutes before
                    //1 hour before
                    for (int i = 0; i < cBSelectedReminders.Items.Count; i++)
                    {
                        BeforeNotificationTime notifyTime = new BeforeNotificationTime();
                        string time;
                        time = cBSelectedReminders.Items[i].ToString();
                        string an = "";
                        for (int k = 0; k < time.Length; k++)
                        {
                            if (time[k] == ' ')
                                break;
                            an += (time[k].ToString());
                        }

                        int timeValue = Convert.ToInt32(an);


                        //MessageBox.Show(timeValue.ToString());

                        if (cBSelectedReminders.Items[i].ToString().Contains("minutes before - NO"))
                        {

                            //MessageBox.Show("Inside Minutes Part");
                            notifyTime.NotifyTimeBeforeString = cBSelectedReminders.Items[i].ToString();

                            notifyTime.Date = dateTimePicker2.Value.ToShortDateString();
                            DateTime tm = dateTimePicker1.Value;
                            DateTime tm2 = tm.AddMinutes(timeValue);
                            TimeSpan t = tm2 - tm;
                            tm = tm - t;
                            notifyTime.Time = tm.ToShortTimeString();


                            //MessageBox.Show(tm.ToShortTimeString());


                            if (cBSelectedReminders.Items.ToString().Contains("EM"))
                                notifyTime.Notify_Via = 2;
                            if (cBSelectedReminders.Items.ToString().Contains("SM"))
                                notifyTime.Notify_Via = 3;
                            else
                                notifyTime.Notify_Via = 1;



                            notificationTimeList.Add(notifyTime);

                        }
                        else if (cBSelectedReminders.Items[i].ToString().Contains("hours before - NO"))
                        {


                            //MessageBox.Show("Inside Hours Part");
                            notifyTime.NotifyTimeBeforeString = cBSelectedReminders.Items[i].ToString();

                            notifyTime.Date = dateTimePicker2.Value.ToShortDateString();
                            DateTime tm = dateTimePicker1.Value;
                            DateTime tm2 = tm.AddHours(timeValue);
                            TimeSpan t = tm2 - tm;
                            tm = tm - t;
                            notifyTime.Time = tm.ToShortTimeString();


                            if (cBSelectedReminders.Items.ToString().Contains("EM"))
                                notifyTime.Notify_Via = 2;
                            if (cBSelectedReminders.Items.ToString().Contains("SM"))
                                notifyTime.Notify_Via = 3;
                            else
                                notifyTime.Notify_Via = 1;


                            notificationTimeList.Add(notifyTime);
                        }
                        else if (cBSelectedReminders.Items[i].ToString().Contains("days before - NO"))
                        {

                            //MessageBox.Show("Inside Days Part");
                            notifyTime.NotifyTimeBeforeString = cBSelectedReminders.Items[i].ToString();

                            DateTime tm = dateTimePicker1.Value;
                            DateTime tm2 = tm.AddDays(timeValue);
                            TimeSpan t = tm2 - tm;
                            tm = tm - t;
                            notifyTime.Date = tm.ToShortDateString();
                            notifyTime.Time = dateTimePicker1.Value.ToShortTimeString();


                            if (cBSelectedReminders.Items.ToString().Contains("EM"))
                                notifyTime.Notify_Via = 2;
                            if (cBSelectedReminders.Items.ToString().Contains("SM"))
                                notifyTime.Notify_Via = 3;
                            else
                                notifyTime.Notify_Via = 1;


                            notificationTimeList.Add(notifyTime);
                        }
                        else
                        {
                            //MessageBox.Show("Inside Weeks Part");
                            notifyTime.NotifyTimeBeforeString = cBSelectedReminders.Items[i].ToString();

                            DateTime tm = dateTimePicker1.Value;
                            DateTime tm2 = tm.AddDays(timeValue * 7);
                            TimeSpan t = tm2 - tm;
                            tm = tm - t;
                            notifyTime.Date = tm.ToShortDateString();
                            notifyTime.Time = dateTimePicker1.Value.ToShortTimeString();


                            if (cBSelectedReminders.Items.ToString().Contains("EM"))
                                notifyTime.Notify_Via = 2;
                            if (cBSelectedReminders.Items.ToString().Contains("SM"))
                                notifyTime.Notify_Via = 3;
                            else
                                notifyTime.Notify_Via = 1;



                            notificationTimeList.Add(notifyTime);
                        }
                    }


                }

                ts.Repeat_Date_List = repeateDateList;
                ts.Notify_Time_List = notificationTimeList;


                TaskSer taskService = new TaskSer();

                List<int> taskID = taskService.Insert(ts);

                taskService = new TaskSer();

                taskService.InsertInNotificationTime(taskID, ts);

                MessageBox.Show("Task Is Added!!!");

                this.Close();


                UserControlForOnlyTestPurpose.uC.LoadTaskList();

            }
            else
                MessageBox.Show("You Should be Put the task tittle!!!");
        }



        private void cBSelectReminder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cBSelectReminder.SelectedItem.ToString().Equals("Custom"))
            {
                CustomNoficationForm cNF = new CustomNoficationForm();
                cNF.Show();
            }
        }

        private void cBRepeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBRepeat.SelectedItem.ToString().Equals("Custom"))
            {
                CustomRepeatDate crd = new CustomRepeatDate();
                crd.Show();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
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
    }
}
