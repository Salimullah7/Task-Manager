using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NotificationPopUp
    {
        string _taskName;
        string _description;
        string _time;
        int _taskID;
        int _notify_Via;

        public string Name
        {
            get { return _taskName; }
            set { _taskName = value; }
        }
        public int Task_ID
        {
            get { return _taskID; }
            set { _taskID = value; }
        }
        public int Notify_Via
        {
            get { return _notify_Via; }
            set { _notify_Via = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }
    }
}
