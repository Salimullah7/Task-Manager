using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ShareTask
    {
        int _senderID;
        int _receiverID;
        int _task_ID;
        int _cat_ID;

        public int SenderID{ get { return _senderID; } set { _senderID = value; } }
        public int ReceiverId { get { return _receiverID; } set { _receiverID = value; } }
        public int Task_ID { get { return _task_ID; } set { _task_ID = value; } }
        public int Cat_ID { get { return _cat_ID; } set { _cat_ID = value; } }

    }
}
