using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary.Interfaces
{
    public interface ICrudUser<T>
    {
        void Insert(T sql, T username, T password, T email);

        void Delete(T sqlCmd, T selectedDes);

        T GetById(T sqlCmd, int id);

        List<T> GetAll(T sql);

        T Selected(T sql, T selectedName);
    }
}
