using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace Repositories
{
    public class DataAccess : IDisposable
    {
        static SqlConnection connection;
        static SqlCommand command;

        public DataAccess()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TaskManagement"].ConnectionString);
            connection.Open();
            
        }

        public SqlDataReader GetData(string sql)
        {
            using (command = new SqlCommand(sql, connection))
            {
                return command.ExecuteReader();
            }
        }

        public SqlDataAdapter GetDataByAdapter(string sql)
        {
            using (SqlDataAdapter sq = new SqlDataAdapter(sql, connection))
            {
                return sq;
            }
                
        }

        public int ExecuteQuery(string sql)
        {
            using (command = new SqlCommand(sql, connection))
            {
                return command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
