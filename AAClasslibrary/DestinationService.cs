using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DestinationService
    {
        private static IDestinationRepository _destinationRepository;

        public static void Initialize(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        private static Destination FromDTO(DestinationDTO dto)
        {
            var des = new Destination()
            {
                Name = dto.Name,
                Country = dto.Country,
                Climate = dto.Climate,
                Currency = dto.Currency,
                BriefDescription = dto.BriefDescription,
                AvgRating = dto.AvgRating,
                ImgURL = dto.ImgURL,
            };
            return des;
        }
        public static void InsertDestination(DestinationDTO destination)
        {
            var desInstance = FromDTO(destination);

            if (!Validate(desInstance)) { return; }
            else
            {
                _destinationRepository.InsertDestination(destination);
            }

        }
        public static void DeleteDestination(string selectedDes)
        {
            _destinationRepository.DeleteDestination(selectedDes);
        }
        public static List<Destination> GetDestinationByName(string name)
        {
            var dto = _destinationRepository.GetDestinationByName(name);
            List<Destination> result = new List<Destination>();
            foreach(var des in dto)
            {
                result.Add(FromDTO(des));
            }
            return result;
        }
        public static List<Destination> GetAllDestinationsByCountry(string country)
        {
            List<DestinationDTO> destinationDtos = _destinationRepository.GetAllDestinationsByCountry(country);
            List<Destination> destinations = new List<Destination>();
            foreach(var des in destinationDtos)
            {
                destinations.Add(FromDTO(des));
            }
            return destinations;
        }
        public static bool Validate(Destination des)
        {
            var context = new ValidationContext(des);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(des, context, results, true);
        }
    }
}
