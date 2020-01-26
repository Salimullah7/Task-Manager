using Entity;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager
{
    public delegate void CustomNotifyDel(NotificationPopUp obj);
    public partial class LogIn : Form
    {
        SmtpClient client;
        MailMessage msg;

        public static int user_ID;
        static CustomNotificationPopUp cs;
        static NotificationPopUp notifyPopUp;
        UserSer us;
        public static LogIn log;


        int mov;
        int movX;
        int movY;


        public LogIn()
        {
            log = this;
            InitializeComponent();
            ForGetEveryMinuteNotifyTime();
        }

        private async void ForGetEveryMinuteNotifyTime()
        {
            Task<Int64> ts = new Task<Int64>(GetAllTodayRemindersDataFromDatabase);
            ts.Start();
            Int64 i = await ts;
        }

        private Int64 GetAllTodayRemindersDataFromDatabase()
        {
            List<NotificationPopUp> timeList;
            TaskSer ts = new TaskSer();
            while (true)
            {
                timeList = ts.GetAllTodayNotificationTime();
                for (int i = 0; i < timeList.Count; i++)
                {
                    if (timeList[i].Time.Equals(DateTime.Now.ToString("hh:mm tt")))
                    {
                        if (cs != null)
                        {
                            if(timeList[i].Task_ID != notifyPopUp.Task_ID)
                            {
                                CustomNotifyDel ac = new CustomNotifyDel(CustomNotificationPopUp);
                                BeginInvoke(ac, timeList[i]);
                            }
                        }
                        if (cs == null)
                        {
                            CustomNotifyDel ac = new CustomNotifyDel(CustomNotificationPopUp);
                            BeginInvoke(ac, timeList[i]);
                        }
                        break;
                    }
                }
                Thread.Sleep(60000);
            }
        }

        private void CustomNotificationPopUp(NotificationPopUp obj)
        {
            notifyPopUp = obj;
            if(obj.Notify_Via == 1)
            {
                us = new UserSer();
                string uEmail = us.GetUserEmail(LogIn.user_ID);
                string ms = obj.Name + "\n\n\n\n" + obj.Description;
                SendEMail(uEmail,ms);
            }
            else if(obj.Notify_Via == 2)
            {
                MessageBox.Show("This is Not Updated Yet. Bacause It has Money to get this service");
            }
            else
            {
                cs = new CustomNotificationPopUp();
                cs.Top = 30;
                cs.Left = Screen.PrimaryScreen.Bounds.Width - cs.Width - 30;
                cs.setLabel(obj.Name, obj.Description);
                cs.Show();
            }
        }
        public void SendEMail(string email, string ms)
        {
            msg = new MailMessage("tracer.task.708@gmail.com", email, "You have a Task Now", ms);
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new NetworkCredential("tracer.task.708@gmail.com", "88538712");
            client.EnableSsl = true;
            client.Send(msg);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            tBoxUName.Select();
        }

        private void btnAddCategory_Click_1(object sender, EventArgs e)
        {
            us = new UserSer();
            user_ID = us.LoginValidity(tBoxUName.Text, tBoxPassword.Text);
            if (user_ID != 0)
            {
                this.Hide();
                HomePage2.home2 = new HomePage2("Inbox");
                HomePage2.home2.Show();
            }
            else
                MessageBox.Show("User Name and Password invalid!!");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SignUp sU = new SignUp();
            sU.Show();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
    }
}
