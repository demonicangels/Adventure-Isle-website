using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TravelListService
    {
        ITravelListRepository listRepository;

        public ITravelListRepository Init(ITravelListRepository t) 
        {
            return listRepository = t;
        }
        private TravelList FromDTO (TravelListDTO t)
        {
           return new TravelList() 
           { 
               Id = t.Id,
               UserId = t.UserId,
               DestinationId = t.DestinationId,
               Necessities = t.Necessities,
           };

        }
        private TravelListDTO ToDTO (TravelList t)
        {
            return new TravelListDTO()
            {
                Id = t.Id,
                UserId = t.UserId,
                DestinationId = t.DestinationId,
                Necessities = t.Necessities,
            };
        }
        public TravelList CreateList(TravelList t)
        {
            if (!Validate(t)) { return null; }
            else
            {
                t = FromDTO(listRepository.CreateTravelList(ToDTO(t)));
                return t;
            }
        }

        public TravelList GetListByUserId(int id)
        {
            var list = listRepository.GetListByUserId(id);
            return FromDTO(list);
        }
        public TravelList UpdateTravelList(TravelList t)
        {
            if (!Validate(t)) { return null; }
            else
            {
                return FromDTO(listRepository.UpdateTravelList(ToDTO(t)));
            }

        }
        public bool Validate(TravelList t)
        {
            var context = new ValidationContext(t);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(t, context, results, true);
        }
    }
}
