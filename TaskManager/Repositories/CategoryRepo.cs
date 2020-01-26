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
    public class CategoryRepo: IRepositories<Category>
    {
        DataAccess dataAccess;
        public CategoryRepo()
        {
            dataAccess = new DataAccess();
        }

        public int Delete(Category obj, int uID)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(int uID)
        {
            string sql = "SELECT * FROM Categories where User_ID = "+uID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                List<Category> categories = new List<Category>();
                while (reader.Read())
                {
                    Category cat = new Category();
                    cat.Name = reader["Category_Name"].ToString();
                    cat.Color = Convert.ToInt32(reader["Category_Color"]);
                    categories.Add(cat);
                }
                return categories;
            }
        }
        public List<string> GetAll(string name, int uID)
        {
            string sql = "SELECT Category_Name FROM Categories where User_ID = '"+uID+"' and Category_Name like '"+name+"'+'%'";
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                List<string> listName = new List<string>();
                string na;
                while (reader.Read())
                {
                    na = reader["Category_Name"].ToString();
                    listName.Add(na);
                }
                return listName;
            }
                
        }
        public int GetCatID(string catName, int uID)
        {
            string sql = "SELECT Category_ID FROM Categories where Category_Name = '"+catName+"' and User_ID = "+uID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                reader.Read();
                if (reader.HasRows)
                    return Convert.ToInt32(reader["Category_ID"]);
                return 12345;
            }
        }
        public string GetCatName(int catID, int uID)
        {
            string sql = "SELECT Category_Name FROM Categories where Category_ID = '" + catID + "' and User_ID = "+uID;
            using (SqlDataReader reader = dataAccess.GetData(sql))
            {
                reader.Read();
                if (reader.HasRows)
                    return reader["Category_Name"].ToString();
                return "";
            }
        }

        public int Insert(Category obj, int uID)
        {
            string sql = "INSERT INTO Categories(Category_Name,Category_Color,User_ID) VALUES('" + obj.Name + "','" + obj.Color + "','" + obj.UserID + "')";
            return dataAccess.ExecuteQuery(sql);
        }

        public int Update(Category obj, int uID)
        {
            throw new NotImplementedException();
        }
    }
}
