using Entity;
using Interfaces;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategorySer : IRepositories<Category>
    {
        CategoryRepo cRepo;
        DataAccess dataAccess;
        public CategorySer()
        {
            cRepo = new CategoryRepo();
        }
        public int Delete(Category obj, int uID)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(int uID)
        {
            return cRepo.GetAll(uID);


        }
        public List<string> GetAll(string name, int uID)
        {
            return cRepo.GetAll(name, uID);


        }
        public int GetCategoryID(string catName, int uID)
        {
            return cRepo.GetCatID(catName, uID);

        }
        public string GetCategoryName(int catID, int uID)
        {
            return cRepo.GetCatName(catID, uID);

        }
        public int Insert(Category obj, int uID)
        {
            return cRepo.Insert(obj, uID);

        }

        public int Update(Category obj, int uID)
        {
            throw new NotImplementedException();
        }
    }
}
