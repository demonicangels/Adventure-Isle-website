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

        public TravelListService(ITravelListRepository t) 
        {
            listRepository = t;
        }

        private TravelList FromDTO (TravelListDTO t)
        {
           return new TravelList() 
           { 
               UserId = t.UserId,
               DestinationId = t.DestinationId,
               Necessities = t.Necessities,
           };

        }
        private TravelListDTO ToDTO (TravelList t)
        {
            return new TravelListDTO()
            {
                UserId = t.UserId,
                DestinationId = t.DestinationId,
                Necessities = t.Necessities,
            };
        }
        public void CreateList(TravelList t)
        {
            if (!Validate(t)) { return; }
            else
            {
                listRepository.CreateTravelList(ToDTO(t));
            }
        }

        public TravelList GetListByUserId(int id)
        {
            var list = listRepository.GetListByUserId(id);
            return FromDTO(list);
        }
        public void UpdateTravelList(TravelList t)
        {
            if (!Validate(t)) { return; }
            else
            {
                listRepository.UpdateTravelList(ToDTO(t));
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
