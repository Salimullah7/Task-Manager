using Entity;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TasksRepo : IDisposable
    {
        DataAccess dataAccess;
        public TasksRepo()
        {
            dataAccess = new DataAccess();
        }
        public int Delete(Tasks obj)
        {
            throw new NotImplementedException();
        }
        public void Delete(int taskID)
        {
            string sql = "Delete from NotifiyTime where Task_ID = " + taskID;
            dataAccess.ExecuteQuery(sql);

            sql = "Delete from Tasks where Task_ID = "+taskID;
            dataAccess.ExecuteQuery(sql);
        }
        public void DeleteByRepeatID(string rpID)
        {
            string sql = "Delete from NotifiyTime where Repeat_Task_ID = '" + rpID + "'";
            dataAccess.ExecuteQuery(sql);

            sql = "Delete from Tasks where Task_Repeat_Date = '"+rpID+"'";
            dataAccess.ExecuteQuery(sql);
        }

        public void DeleteNotificationTimeByTaskID(int taskID)
        {
            string sql = "Delete from NotifiyTime where Task_ID = "+taskID;
            dataAccess.ExecuteQuery(sql);
        }


        public int GetAllCompleteTaskCountByDate(string date)
        {
            string sql = "SELECT Count(*) as Sajib from Tasks where Task_Date = '" + date + "' and Complete = "+1;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                reader.Read();
                return (int)reader["Sajib"];
            }
        }




        public List<NotificationPopUp> GetAllTodayNotificationTime()
        {
            
            string sql = "SELECT t.Task_ID,n.Notify_Via,Task_Tittle,Task_Description,Notify_Time FROM NotifiyTime n,Tasks t where Notify_Date = '" + DateTime.Now.ToShortDateString()+ "' and t.Task_ID = n.Task_ID  and t.Task_Repeat_Date = n.Repeat_Task_ID";
            List<NotificationPopUp> timeList = new List<NotificationPopUp>();
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NotificationPopUp npu = new NotificationPopUp();
                        npu.Time = reader["Notify_Time"].ToString();
                        npu.Name = reader["Task_Tittle"].ToString();
                        npu.Description = reader["Task_Description"].ToString();
                        npu.Task_ID = (int)reader["Task_ID"];
                        npu.Notify_Via = (int)reader["Notify_Via"];
                        timeList.Add(npu);
                    }
                }
                

                return timeList;
            }
        }

        public int GetNoOfTaskOfRepeatID(string rpID)
        {
            int count = 0;
            string sql = "SELECT Task_ID FROM Tasks where Task_Repeat_Date = '" + rpID+"'";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                while (reader.Read())
                {
                    if (count > 5)
                        break;
                    count++;
                }

                return count;
            }
        }


        public int GetTaskID(string tittle, int catID)
        {
            string sql = "SELECT Task_ID FROM Tasks where Complete = 0 and Task_Tittle = '"+tittle+"' and Category_ID = "+catID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                reader.Read();
                return (int)reader["Task_ID"];
            }
        }
        public List<int> GetAllTaskID(int catID)
        {
            List<int> taskID = new List<int>();
            string sql = "SELECT Task_ID FROM Tasks where Complete = 0 and Category_ID = " + catID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                while (reader.Read())
                {
                    taskID.Add((int)reader["Task_ID"]);
                }
                return taskID;
            }
        }
        public string GetTaskTittle(int catID, int taskID)
        {
            string sql = "SELECT Task_Tittle FROM Tasks where Complete = 0 and Task_ID = '" + taskID + "' and Category_ID = " + catID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                reader.Read();
                if (reader.HasRows)
                    return reader["Task_Tittle"].ToString();
                return "";
            } 
        }
        public void Dispose()
        {
            dataAccess.Dispose();
        }


        public List<Tasks> GetAll()
        {
            string sql = "SELECT * FROM Tasks where Complete = 0";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                return GetAllDataFromSqlDataReader(reader);
            }
        }



        public Tasks GetAllInfoByTaskID(int taskID)
        {
            string sql = "SELECT * FROM Tasks where Task_ID = " + taskID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                Tasks ts = new Tasks();
                reader.Read();
                ts.Task_ID = (int)reader["Task_ID"];
                ts.Tittle = reader["Task_Tittle"].ToString();
                ts.Time = reader["Task_Time"].ToString();
                ts.Date = reader["Task_Date"].ToString();
                ts.Description = reader["Task_Description"].ToString();
                ts.Priority = (int)reader["Task_Priority"];
                ts.RepeatDateTask_ID = reader["Task_Repeat_Date"].ToString();
                ts.Category_ID = (int)reader["Category_ID"];
                ts.Task_Complete = (int)reader["Complete"];
                ts.RepeatName = GetRepeatNameByRepeatID(ts.RepeatDateTask_ID);
                //dataAccess = new DataAccess();
                ts.Notify_Time_List = GetAllNotifyInfoByTaskID(taskID);
                return ts;
            }
                
        }

        public string GetRepeatNameByRepeatID(string rpID)
        {
            dataAccess = new DataAccess();
            string sql = "SELECT Repeat_Name FROM Repeated_TaskInfo where Repeat_ID = '"+rpID+"'";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                reader.Read();
                if (reader.HasRows)
                    return reader["Repeat_Name"].ToString();
                return "";
            }
                
        }


        public List<BeforeNotificationTime> GetAllNotifyInfoByTaskID(int taskID)
        {
            List<BeforeNotificationTime> notify = new List<BeforeNotificationTime>();

            string sql = "SELECT * FROM NotifiyTime where Task_ID = " + taskID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                while (reader.Read())
                {
                    BeforeNotificationTime bfT = new BeforeNotificationTime();
                    bfT.NotifyTimeBeforeString = reader["Notify_Time_Before"].ToString();
                    notify.Add(bfT);
                }

                return notify;
            }
        }


        public List<Tasks> GetAll(int cat_ID)
        {
            string sql = "SELECT * FROM Tasks where Complete = 0 and Category_ID ="+cat_ID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                return GetAllDataFromSqlDataReader(reader);
            }
        }



        public DataTable GetAllByReader(int cat_ID)
        {
            string sql = "SELECT * FROM Tasks where Complete = 0 and Category_ID =" + cat_ID;
            using (SqlDataAdapter reader = dataAccess.GetDataByAdapter(sql))
            {
                DataTable dt = new DataTable();
                reader.Fill(dt);
                return dt;
            }
        }



        public List<Tasks> GetSortByDate(int cat_ID)
        {
            string sql = "SELECT * FROM Tasks where Complete = 0 and Category_ID = '" +cat_ID+ "' order by Task_Date ASC";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                return GetAllDataFromSqlDataReader(reader);
            }
        }


        private List<Tasks> GetAllDataFromSqlDataReader(SqlDataReader reader)
        {
            List<Tasks> tasks = new List<Tasks>();
            while (reader.Read())
            {
                Tasks task = new Tasks();
                task.Task_ID = (int)reader["Task_ID"];
                task.Tittle = reader["Task_Tittle"].ToString();
                if (!DBNull.Value.Equals(reader["Task_Time"]))
                    task.Time = reader["Task_Time"].ToString();
                if (!DBNull.Value.Equals(reader["Task_Date"]))
                    task.Date = reader["Task_Date"].ToString();
                if (!DBNull.Value.Equals(reader["Task_Description"]))
                    task.Description = reader["Task_Description"].ToString();
                if (!DBNull.Value.Equals(reader["Task_Repeat_Date"]))
                    task.RepeatDateTask_ID = reader["Task_Repeat_Date"].ToString();
                if (!DBNull.Value.Equals(reader["Task_Priority"]))
                    task.Priority = (int)reader["Task_Priority"];
                
                task.Category_ID = (int)reader["Category_ID"];

                tasks.Add(task);
            }
            reader.Close();
            return tasks;
        }



        public List<Tasks> GetSortByPriority(int cat_ID)
        {
            string sql = "SELECT * FROM Tasks where Complete = 0 and Category_ID = '" + cat_ID + "' order by Task_Priority ASC";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                return GetAllDataFromSqlDataReader(reader);
            }
        }



        public List<Tasks> GetSortByTittle(int cat_ID)
        {
            string sql = "SELECT * FROM Tasks where Complete = 0 and Category_ID = '" + cat_ID + "' order by Task_Tittle ASC";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                return GetAllDataFromSqlDataReader(reader);
            }
        }





        public List<Tasks> GetAllCompleteOrNotTask(int completeOrNot, int cat_ID)
        {
            string sql = "SELECT * FROM Tasks where Category_ID = '"+cat_ID+"' and Complete ="+ completeOrNot;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                return GetAllDataFromSqlDataReader(reader);
            }
        }

        private List<int> GetTaskIDByRepeatID(string repeatID)
        {
            List<int> taskID = new List<int>();
            //dataAccess = new DataAccess();
            string sql = "SELECT Task_ID FROM Tasks where Task_Repeat_Date = '" + repeatID + "'";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                while (reader.Read())
                {
                    taskID.Add((int)reader["Task_ID"]);
                }
                //dataAccess.Dispose();
                return taskID;
            } 
        }

        public List<int> Insert(Tasks obj)
        {
            if(obj.Repeat_Date_List.Count == 0)
            {
                string sql = "INSERT INTO Tasks(Task_Tittle,Task_Time,Task_Date,Task_Description,Task_Priority,Task_Repeat_Date,Category_ID,Complete) VALUES('" + obj.Tittle + "','" + obj.Time + "','" + obj.Date + "','" + obj.Description + "','" + obj.Priority + "','" + obj.RepeatDateTask_ID + "','" + obj.Category_ID + "','" + obj.Task_Complete + "')";
                dataAccess.ExecuteQuery(sql);

                sql = "INSERT INTO Repeated_TaskInfo(Repeat_ID, Repeat_Name) VALUES('" + obj.RepeatDateTask_ID + "','" + obj.RepeatName + "')";
                dataAccess.ExecuteQuery(sql);

            }
            for(int i=0; i<obj.Repeat_Date_List.Count; i++)
            {
                string sql = "INSERT INTO Tasks(Task_Tittle,Task_Time,Task_Date,Task_Description,Task_Priority,Task_Repeat_Date,Category_ID,Complete) VALUES('" + obj.Tittle + "','" + obj.Time + "','" + obj.Repeat_Date_List[i] + "','" + obj.Description + "','" + obj.Priority + "','" + obj.RepeatDateTask_ID + "','" + obj.Category_ID + "','" + obj.Task_Complete + "')";
                dataAccess.ExecuteQuery(sql);
            }
            List<int> taskID = GetTaskIDByRepeatID(obj.RepeatDateTask_ID);
            return taskID;
        }



        public void InsertFormImportFile(Tasks obj)
        {
            string sql = "INSERT INTO Repeated_TaskInfo(Repeat_ID, Repeat_Name) VALUES('" + obj.RepeatDateTask_ID + "','" + obj.RepeatName + "')";
            dataAccess.ExecuteQuery(sql);

            obj.RepeatDateTask_ID = 

            sql = "INSERT INTO Tasks(Task_Tittle,Task_Time,Task_Date,Task_Description,Task_Priority,Task_Repeat_Date,Category_ID,Complete) VALUES('" + obj.Tittle + "','" + obj.Time + "','" + obj.Date + "','" + obj.Description + "','" + obj.Priority + "','" + obj.RepeatDateTask_ID + "','" + obj.Category_ID + "','" + obj.Task_Complete + "')";
            dataAccess.ExecuteQuery(sql);

            
        }



        public void InsertInNotificationTime(List<int> tasksID, Tasks obj)
        {
            for (int i = 0; i<tasksID.Count; i++)
            {
                for(int j=0; j<obj.Notify_Time_List.Count; j++)
                {
                    dataAccess = new DataAccess();
                    string sql = "INSERT INTO NotifiyTime(Notify_Time,Task_ID,Notify_Date,Notify_Via,Notify_Time_Before,Repeat_Task_ID) VALUES('" + obj.Notify_Time_List[j].Time + "','" + tasksID[i] + "','" + obj.Notify_Time_List[j].Date + "','" + obj.Notify_Time_List[j].Notify_Via + "','" + obj.Notify_Time_List[j].NotifyTimeBeforeString + "','" + obj.RepeatDateTask_ID + "')";
                    dataAccess.ExecuteQuery(sql);
                    dataAccess.Dispose();
                }
                
            }
            
        }
        public void InsertInNotificationTime(Tasks obj)
        {
            for (int j = 0; j < obj.Notify_Time_List.Count; j++)
            {
                string sql = "INSERT INTO NotifiyTime(Notify_Time,Task_ID,Notify_Date,Notify_Via,Notify_Time_Before,Repeat_Task_ID) VALUES('" + obj.Notify_Time_List[j].Time + "','" + obj.Task_ID + "','" + obj.Notify_Time_List[j].Date + "','" + obj.Notify_Time_List[j].Notify_Via + "','" + obj.Notify_Time_List[j].NotifyTimeBeforeString + "','" + obj.RepeatDateTask_ID + "')";
                dataAccess.ExecuteQuery(sql);
            }

        }
        private void InsertNotificationTimes()
        {

        }

        public int Update(Tasks obj)
        {
            string sql = "UPDATE Tasks SET Task_Tittle ='" + obj.Tittle + "',Task_Description ='" + obj.Description + "',Task_Priority ='" + obj.Priority + "',Task_Date ='" + obj.Date + "',Task_Time ='" + obj.Time + "',Task_Repeat_Date ='" + obj.RepeatDateTask_ID + "',Category_ID ='" + obj.Category_ID + "' WHERE Task_ID=" + obj.Task_ID;
            dataAccess.ExecuteQuery(sql);

            DeleteNotificationTimeByTaskID(obj.Task_ID);
            InsertInNotificationTime(obj);

            return 1;
        }
        public int Update(int task_ID, int value)
        {
            string sql = "UPDATE Tasks SET Complete='" + value + "' WHERE Task_ID=" + task_ID;
            return dataAccess.ExecuteQuery(sql);
        }


        public List<Tasks> GetSearchByChacter(string ch)
        {
            string sql = "SELECT * FROM Tasks where Task_Tittle like '"+ch+"%'";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                return GetAllDataFromSqlDataReader(reader);
            }
        }


    }
}
