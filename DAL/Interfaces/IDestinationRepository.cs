using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IDestinationRepository<T>
    {

        void InsertDestination(T destination);

        void DeleteDestination(string selectedDes);

        public string GetDestinationByName(string name);

        List<T> GetAllDestinations();

    }
}
