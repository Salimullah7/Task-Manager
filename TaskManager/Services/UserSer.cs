using Entity;
using Interfaces;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserSer
    {
        UserRepo up;
        public UserSer()
        {
            up = new UserRepo();
        }
        public int LoginValidity(string uname, string pass)
        {
            return up.LoginValid(uname, pass);
        }
        public int GetUserID(string uname)
        {
            return up.GetID(uname);
        }
        public string GetUserEmail(int uID)
        {
            return up.GetUserEmail(uID);
        }
        public int GetUserIdByEmail(string uname)
        {
            return up.GetIDByEmail(uname);
        }
        public bool EmailValidity(string email)
        {
            return up.EmailValidity(email);
        }
        public int Insert(User obj)
        {
            return up.Insert(obj);
        }
        public int Delete(int viewerID, int uID)
        {
            return up.Delete(viewerID, uID);
        }
        public int Delete(int viewerID, int uID, int catID)
        {
            return up.Delete(viewerID, uID, catID);
        }
        public int Delete(int viewerID, int uID, int catID, int taskID)
        {
            return up.Delete(viewerID, uID, catID, taskID);
        }
        public int Update(User obj)
        {
            return up.Update(obj);
        }

        public int Delete(User obj)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }
        public User GetAll(int uID)
        {
            return up.GetAll(uID);
        }
    }
}
