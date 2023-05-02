using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITravelListRepository
    {
        TravelListDTO CreateTravelList(TravelListDTO travelList);
        TravelListDTO GetListByUserId(int id);
        List<string> GetNecessities();
        TravelListDTO UpdateTravelList(TravelListDTO travelList);
    }
}
