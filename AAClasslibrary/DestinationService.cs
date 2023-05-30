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

        public DestinationService(IDestinationRepository des)
        {
            _destinationRepository = des;
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
                DesStatus = dto.DesStatus,
                UsrId = dto.UsrId,
            };
            return des;
        }
		private DestinationDTO ToDTO(Destination d)
		{
			var des = new DestinationDTO()
			{
                Id = d.Id,
				Name = d.Name,
				Country = d.Country,
				Climate = d.Climate,
				Currency = d.Currency,
				BriefDescription = d.BriefDescription,
				AvgRating = d.AvgRating,
				ImgURL = d.ImgURL,
                DesStatus = d.DesStatus,
                UsrId = d.UsrId,
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
            try
            {
                var dto = _destinationRepository.GetDestinationByName(name);
                List<Destination> result = new List<Destination>();
                foreach (var des in dto)
                {
                    result.Add(FromDTO(des));
                }
                return result;
            }
            catch (DestinationNotFoundException desNotFoundEx)
            {
               
                Console.WriteLine(desNotFoundEx.Message);  // log exception
                throw new Exception("Something went wrong");
            }
 
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
        public Destination SetDestinationStatus(Destination d, int id)
        {
            if (!Validate(d)) { return null; }
            else 
            {
                _destinationRepository.SetDestinationStatus(ToDTO(d), id);
                return d;
			}

        }
        public Destination GetDestinationWithStatus(Destination des, int usrId)
        {
            if (!Validate(des)) { return null; }
            else
            {
                var desi = _destinationRepository.GetStatusByUserIdAndDesId(ToDTO(des), usrId);
                return FromDTO(desi);
			}
           
        }
        public Destination UpdateStatusByUserIdAndDesId(Destination des, int usrId)
        {
            if (!Validate(des)) { return null; }
            else
            {
                var desi = _destinationRepository.UpdateStatusByUserIdAndDesId(ToDTO(des), usrId);
                return FromDTO(desi);
			}
        }

        public bool InfoInputValidation(string name, string currency, string climate)
        {
            int amount;
            var result = int.TryParse(name, out amount);
            var result2 = int.TryParse(currency, out amount);
            var result3 = int.TryParse(climate, out amount);

            if(result2 == true)
            {
                result = result2;

            }
            else if(result3 == true)
            {
                result = result3;
            }

            return result;
        }
        public bool SearchValidation(string search)
        {
            int amount;
            var result = int.TryParse(search, out amount);

            return result;
        }
        public Destination[] AllDesOfUser(int usrId)
        {
            var allDes = _destinationRepository.AllDestinationsofUser(usrId);
            List<Destination> result = new List<Destination>();
            foreach(var d in allDes)
            {
                result.Add(FromDTO(d));
            }
            return result.ToArray();
		} 
        public Destination[] GetAllDestinations()
        {
            var desiList = _destinationRepository.GetAllDestinations();
            List<Destination> result = new List<Destination>();
            foreach(var d in desiList)
            {
                result.Add(FromDTO(d));
            }
            return result.ToArray();
		}
		public bool Validate(Destination des)
        {
            var context = new ValidationContext(des);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(des, context, results, true);
        }
    }
}
