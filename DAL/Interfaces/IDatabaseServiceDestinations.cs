using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAClasslibrary.Interfaces
{
    public interface IDatabaseServiceDestinations<T>
    {

        void InsertDestination(T destination);

        void DeleteDestination(string selectedDes);

        string SearchDestination(string sqlCmd);

        List<T> GetAllDestinations();

        string SelectedDestination(string selectedName);

    }
}
