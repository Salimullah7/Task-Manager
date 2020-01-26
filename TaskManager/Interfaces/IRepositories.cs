using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositories<T> where T:class
    {
        int Insert(T obj, int uID);
        int Update(T obj, int uID);
        int Delete(T obj, int uID);
        List<T> GetAll(int uID);

    }
}
