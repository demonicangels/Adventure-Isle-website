using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TravelListRepository : ITravelListRepository
    {
        public TravelListDTO CreateTravelList(TravelListDTO travelList)
        {
            throw new NotImplementedException();
        }
        public TravelListDTO GetListByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetNecessities()
        {
            throw new NotImplementedException();
        }

        public TravelListDTO UpdateTravelList(TravelListDTO travelList)
        {
            throw new NotImplementedException();
        }
    }
}
