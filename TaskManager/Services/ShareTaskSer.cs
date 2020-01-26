
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
    public class ShareTaskSer : IRepositories<ShareTask>, IDisposable
    {
        ShareTaskRepo stRepo;
        public ShareTaskSer()
        {
            stRepo = new ShareTaskRepo();
        }
        public int Delete(ShareTask obj, int uID)
        {
            throw new NotImplementedException();
        }
        public int Delete(int viewerID)
        {
            return stRepo.Delete(viewerID);
        }

        public List<ShareTask> GetAllShared(int uID)
        {
            return stRepo.GetAllShared(uID);
        }
        public List<int> GetCategoryID(int ownID, int viewID)
        {
            return stRepo.GetCategoryID(ownID, viewID);
        }
        public List<int> GetAllTasksFromShareTasks(int catID)
        {
            return stRepo.GetAllTasksFromShareTasks(catID);
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
            return stRepo.Insert(obj, uID);
        }
        public int Insert(int cat_ID, int task_ID, int ownerID, int viewerID)
        {
            return stRepo.Insert(cat_ID, task_ID, ownerID, viewerID);
        }
        public int Update(ShareTask obj, int uID)
        {
            throw new NotImplementedException();
        }
    }
}
