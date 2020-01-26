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
    public class ShareTaskRepo: IRepositories<ShareTask>, IDisposable
    {
        DataAccess dataAccess;
        public ShareTaskRepo()
        {
            dataAccess = new DataAccess();
        }

        public int Delete(ShareTask obj, int uID)
        {
            throw new NotImplementedException();
        }
        public int Delete(int viewerID)
        {
            string sql = "DELETE FROM SharedTasks WHERE Viewer_ID ='" + viewerID;
            return dataAccess.ExecuteQuery(sql);
        }
        public List<ShareTask> GetAllShared(int uID)
        {
            List<ShareTask> sList = new List<ShareTask>();
            string sql = "SELECT * FROM SharedCategory where Owner_ID = " + uID;
            SqlDataReader reader = dataAccess.GetData(sql);
            while (reader.Read())
            {
                ShareTask cat = new ShareTask();
                cat.ReceiverId = (int)reader["Viewer_ID"];
                cat.Cat_ID = (int)reader["Category_ID"];
                sList.Add(cat);
            }
            return sList;
        }
        public List<int> GetCategoryID(int ownerID, int viewID)
        {
            List<int> sList = new List<int>();
            string sql = "SELECT Category_ID FROM SharedCategory where Viewer_ID = '"+viewID+"' and  Owner_ID = " + ownerID;
            SqlDataReader reader = dataAccess.GetData(sql);
            while (reader.Read())
            {
                sList.Add((int)reader["Category_ID"]);
            }
            return sList;
        }
        public List<int> GetAllTasksFromShareTasks(int catID)
        {
            List<int> taskIDList = new List<int>();
            string sql = "SELECT Task_ID FROM SharedTasks where Category_ID = " + catID;
            SqlDataReader reader = dataAccess.GetData(sql);
            while (reader.Read())
            {
                int taskID = (int)reader["Task_ID"];
                taskIDList.Add(taskID);
            }

            return taskIDList;
        }
        public void Dispose()
        {
            this.Dispose();
        }

        public List<ShareTask> GetAll(int uID)
        {
            throw new NotImplementedException();
        }

        public int Insert(ShareTask obj, int uID)
        {
            string sql = "INSERT INTO SharedCategory(Owner_ID,Viewer_ID,Category_ID) VALUES('" + obj.SenderID + "','" + obj.ReceiverId + "','" + obj.Cat_ID + "')";
            return dataAccess.ExecuteQuery(sql);
        }
        public int Insert(int cat_ID, int task_ID, int ownerID, int viewerID)
        {
            string sql = "INSERT INTO SharedTasks(Category_ID, Task_ID, Owner_ID, Viewer_ID) VALUES('" + cat_ID + "','" + task_ID + "','" + ownerID + "','" + viewerID + "')";
            return dataAccess.ExecuteQuery(sql);
        }
        public int Update(ShareTask obj, int uID)
        {
            throw new NotImplementedException();
        }
    }
}
