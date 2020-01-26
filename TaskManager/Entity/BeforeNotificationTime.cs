using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BeforeNotificationTime
    {
        string _time;
        string _date;
        int _task_ID;
        int _notifyVia;
        string _notifyTimeBeforeString;

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public string NotifyTimeBeforeString
        {
            get { return _notifyTimeBeforeString; }
            set { _notifyTimeBeforeString = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public int Task_ID
        {
            get { return _task_ID; }
            set { _task_ID = value; }
        }
        public int Notify_Via
        {
            get { return _notifyVia; }
            set { _notifyVia = value; }
        }
    }
}
