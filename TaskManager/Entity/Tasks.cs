using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Tasks
    {
        int _task_ID;
        string _tittle;
        string _date;
        string _time;
        string _description;
        string _repeatDateTask_ID;
        int _category_ID;
        int _priority;
        int _complete = 0;
        string _repeatName;
        List<BeforeNotificationTime> _notifyTime;
        List<string> _repeatDateList;

        public int Task_ID
        {
            get { return _task_ID; }
            set { _task_ID = value; }
        }
        public string Tittle
        {
            get { return _tittle; }
            set { _tittle = value; }
        }
        public string RepeatName
        {
            get { return _repeatName; }
            set { _repeatName = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string RepeatDateTask_ID
        {
            get { return _repeatDateTask_ID; }
            set { _repeatDateTask_ID = value; }
        }
        public int Category_ID
        {
            get { return _category_ID; }
            set { _category_ID = value; }
        }
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        public int Task_Complete
        {
            get { return _complete; }
            set { _complete = value; }
        }
        public List<BeforeNotificationTime> Notify_Time_List
        {
            get { return _notifyTime; }
            set { _notifyTime = value; }
        }
        public List<string> Repeat_Date_List
        {
            get { return _repeatDateList; }
            set { _repeatDateList = value; }
        }
    }
}
