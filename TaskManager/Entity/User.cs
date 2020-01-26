using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        string _email;
        string _phone;
        string _uname;
        string _pass;
        int _uID;

        public string UserName
        {
            get { return _uname; }
            set { _uname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Password
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public int UID
        {
            get { return _uID; }
            set { _uID = value; }
        }
    }
}
