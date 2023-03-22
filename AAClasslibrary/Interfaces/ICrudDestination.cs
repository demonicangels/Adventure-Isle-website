using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary.Interfaces
{
    public interface ICrudDestination<T>
    {

        void Insert(string sql, T destination);

        void Delete(string sqlCmd, string selectedDes);

        string Search(string sqlCmd);

        List<string> GetAll(string sql);

        string Selected(string sql, string selectedName);

    }
}
