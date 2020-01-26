using Entity;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepo
    {
        DataAccess dataAccess;
        public UserRepo()
        {
            dataAccess = new DataAccess();
        }
        public int LoginValid(string uname, string pass)
        {
            string sql = "SELECT User_ID FROM Users where User_Name = '"+uname+ "' and User_Password = '" + pass + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            if (reader.HasRows)
                return Convert.ToInt32(reader["User_ID"]); ;
            return 0;
        }
        public bool EmailValidity(string email)
        {
            string sql = "SELECT * FROM Users where User_Email = '" + email + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            if (reader.HasRows)
                return true;
            return false;
        }
        public int GetID(string uname)
        {
            string sql = "SELECT * FROM Users where User_Name = '" + uname + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            if (reader.HasRows)
                return Convert.ToInt32(reader["User_ID"]);
            return 0;
        }
        public string GetUserEmail(int uID)
        {
            string sql = "SELECT User_Email FROM Users where User_ID = '" + uID + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            if (reader.HasRows)
                return reader["User_Email"].ToString();
            return "";
        }
        public int GetIDByEmail(string email)
        {
            string sql = "SELECT User_ID FROM Users where User_Email = '" + email + "'";
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            if (reader.HasRows)
                return Convert.ToInt32(reader["User_ID"]);
            return 0;
        }

        public int Insert(User obj)
        {
            string sql = "INSERT INTO Users(User_Name,User_Email,User_Phone,User_Password) VALUES('" + obj.UserName + "','" + obj.Email + "','" + obj.Phone + "','" + obj.Password + "')";
            return dataAccess.ExecuteQuery(sql);
        }
        public int Delete(int viewerID, int uID)
        {
            string sql = "DELETE FROM SharedCategory WHERE Viewer_ID ='"+viewerID+"' and Owner_ID = '"+uID+"'";
            return dataAccess.ExecuteQuery(sql);
        }
        public int Delete(int viewerID, int uID, int catID)
        {
            Delete(viewerID, uID);
            string sql = "DELETE FROM SharedTasks WHERE Viewer_ID ='" + viewerID + "' and Category_ID = '" + catID + "'and Owner_ID = '" + uID + "'";
            return dataAccess.ExecuteQuery(sql);
        }
        public int Delete(int viewerID, int uID, int catID, int taskID)
        {
            string sql = "DELETE FROM SharedTasks WHERE Viewer_ID ='" + viewerID + "' and Category_ID = '" + catID + "'and Owner_ID = '" + uID + "'and Task_ID = '" + taskID + "'";
            return dataAccess.ExecuteQuery(sql);
        }
        public int Update(User obj)
        {
            string sql = "Update Users SET User_Name = '"+obj.UserName+"', User_Email = '"+obj.Email+"', User_Phone = '"+obj.Phone+"', User_Password = '"+obj.Password+"' where User_ID = "+obj.UID;
            return dataAccess.ExecuteQuery(sql);
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
            string sql = "SELECT * FROM Users where User_ID = "+uID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                reader.Read();
                User uS = new User();
                uS.Email = reader["User_Email"].ToString();
                uS.UserName = reader["User_Name"].ToString();
                uS.Phone = reader["User_Phone"].ToString();
                uS.Password = reader["User_Password"].ToString();

                return uS;
            }
        }
    }
}
