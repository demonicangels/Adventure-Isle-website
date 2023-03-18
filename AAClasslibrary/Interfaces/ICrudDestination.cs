using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary.Interfaces
{
    public interface ICrudDestination<T>
    {

        void Insert(T sql, T country, T name, T currency, T history);

        void Delete(T sqlCmd, T selectedDes);

        T GetById(T sqlCmd, int id);

        List<T> GetAll(T sql);

        T Selected(T sql, T selectedName);

    }
}
