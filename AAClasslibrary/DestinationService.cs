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

        public DestinationService(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        private Destination FromDTO(DestinationDTO dto)
        {
            var des = new Destination()
            {
                Id = dto.Id,
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
		private DestinationDTO ToDTO(Destination dto)
		{
			var des = new DestinationDTO()
			{
                Id = dto.Id,
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
		public void InsertDestination(DestinationDTO destination)
        {
            var desInstance = FromDTO(destination);

            if (!Validate(desInstance)) { return; }
            else
            {
                _destinationRepository.InsertDestination(destination);
            }

        }
        public void DeleteDestination(string selectedDes)
        {
            _destinationRepository.DeleteDestination(selectedDes);
        }
        public List<Destination> GetDestinationByName(string name)
        {
            var dto = _destinationRepository.GetDestinationByName(name);
            List<Destination> result = new List<Destination>();
            foreach(var des in dto)
            {
                result.Add(FromDTO(des));
            }
            return result;
        }
        public List<Destination> GetAllDestinationsByCountry(string country)
        {
            List<DestinationDTO> destinationDtos = _destinationRepository.GetAllDestinationsByCountry(country);
            List<Destination> destinations = new List<Destination>();
            foreach(var des in destinationDtos)
            {
                destinations.Add(FromDTO(des));
            }
            return destinations;
        }
        public Destination UpdateDestination(Destination des)
        {
            
            if (!Validate(des)) { return null; }
            else
            {
                var desi = _destinationRepository.UpdateDestination(ToDTO(des));
                return FromDTO(desi);
			}
			

		}
        public bool Validate(Destination des)
        {
            var context = new ValidationContext(des);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(des, context, results, true);
        }
    }
}
