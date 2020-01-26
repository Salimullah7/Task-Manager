using Entity;
using Interfaces;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TaskSer
    {
        TasksRepo taskRepo;
        public TaskSer()
        {
            taskRepo = new TasksRepo();
        }
        public int Delete(Tasks obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int taskID)
        {
            taskRepo.Delete(taskID);
        }

        public void DeleteByRepeatID(string rpID)
        {
            taskRepo.DeleteByRepeatID(rpID);
        }
        public int GetTaskID(string tittle, int catID)
        {
            return taskRepo.GetTaskID(tittle,catID);
        }
        public List<int> GetAllTaskID(int catID)
        {
            return taskRepo.GetAllTaskID(catID);
        }
        public string GetTaskTittle(int catID, int taskID)
        {
            return taskRepo.GetTaskTittle(catID, taskID);
        }
        public List<Tasks> GetAll()
        {
            return taskRepo.GetAll();
        }

        public List<NotificationPopUp> GetAllTodayNotificationTime()
        {
            return taskRepo.GetAllTodayNotificationTime();
        }


        public int GetAllCompleteTaskCountByDate(string date)
        {
            return taskRepo.GetAllCompleteTaskCountByDate(date);
        }




        public Tasks GetAllInfoByTaskID(int taskID)
        {
            return taskRepo.GetAllInfoByTaskID(taskID);
        }
        public List<Tasks> GetAll(int cat_ID)
        {
            return taskRepo.GetAll(cat_ID);
        }
        public DataTable GetAllDataByReader(int cat_ID)
        {
            return taskRepo.GetAllByReader(cat_ID);
        }
        public List<Tasks> GetAllSortByDate(int cat_ID)
        {
            return taskRepo.GetSortByDate(cat_ID);
        }
        public List<Tasks> GetAllSortByPriority(int cat_ID)
        {
            return taskRepo.GetSortByPriority(cat_ID);
        }
        public List<Tasks> GetAllSortByTittle(int cat_ID)
        {
            return taskRepo.GetSortByTittle(cat_ID);
        }
        public List<Tasks> GetAllCompleteOrNotTask(int completeOrNot, int cat_ID)
        {
            return taskRepo.GetAllCompleteOrNotTask(completeOrNot, cat_ID);
        }


        public int GetNoOfTaskOfRepeatID(string rpID)
        {
            return taskRepo.GetNoOfTaskOfRepeatID(rpID);
        }



        public List<int> Insert(Tasks obj)
        {
            return taskRepo.Insert(obj);
        }

        public void InsertFormImportFile(Tasks obj)
        {
            taskRepo.InsertFormImportFile(obj);
        }


        public void InsertInNotificationTime(List<int> taskID, Tasks obj)
        {
            taskRepo.InsertInNotificationTime(taskID, obj);
        }
        public int Update(Tasks obj)
        {
            return taskRepo.Update(obj);
        }
        public int Update(int task_ID, int value)
        {
            return taskRepo.Update(task_ID, value);
        }

        public List<Tasks> GetSearchByChacter(string ch)
        {
            return taskRepo.GetSearchByChacter(ch);
        }



    }
}
