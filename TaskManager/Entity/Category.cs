using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category
    {
        int _cat_ID;
        string _name;
        int _color;
        int _userID;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public int Cat_ID
        {
            get { return _cat_ID; }
            set { _cat_ID = value; }
        }
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
    }
}
