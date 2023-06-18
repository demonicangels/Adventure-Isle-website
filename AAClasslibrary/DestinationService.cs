using BusinessLogic.Exceptions;
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
            var des = new Destination(dto.Id, dto.Name, dto.Country, dto.Currency, dto.BriefDescription, dto.Climate, dto.AvgRating, dto.ImgURL, dto.UsrId,dto.DesStatus);
            
            return des;
        }
		private DestinationDTO ToDTO(Destination d)
		{
            var des = new DestinationDTO() 
            {
                Id = d.Id,
                Name = d.Name,
                Country = d.Country,
                Currency = d.Currency,
                BriefDescription = d.BriefDescription,
                Climate = d.Climate,
                AvgRating = d.AvgRating,
                ImgURL = d.ImgURL,
                UsrId = d.UsrId,
                DesStatus = d.DesStatus
            };
			return des;
		}
		public void InsertDestination(DestinationDTO destination)
        {
            try
            {
                var des = FromDTO(destination);

                if (!Validate(des)) { return; }
                else
                {
                    _destinationRepository.InsertDestination(destination);
                }

            }
            catch(InvalidInformationException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("The information is not valid. Please try again.");
            }

        }
        public void DeleteDestination(string selectedDes)
        {
            try
            {
                _destinationRepository.DeleteDestination(selectedDes);
            }
            catch (CouldntDeleteException d)
            {
                Console.WriteLine(d.Message);
                throw new Exception("The destination couldn't be deleted. Something went wrong.");
            }
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
               
                Console.WriteLine(desNotFoundEx.Message);
                throw new Exception("Something went wrong. Destination with that name couldn't be found.");
            }
 
        }
        public List<Destination> GetAllDestinationsByCountry(string country)
        {
            List<DestinationDTO> destinationDtos = _destinationRepository.GetAllDestinationsByCountry(country);
            List<Destination> destinations = new List<Destination>();
            try
            {                
                foreach(var des in destinationDtos)
                {
                    destinations.Add(FromDTO(des));
                }
                return destinations;
            }
            catch(NoDestinationsFoundForCountryException ex) 
            {
                Console.WriteLine(ex.Message);
                throw new Exception("No destinations for this country are found");
            }
           
        }
        public Destination UpdateDestination(Destination des)
        {
            try
            {
                if (!Validate(des)) { return null; }
                else
                {
                    var desi = _destinationRepository.UpdateDestination(ToDTO(des));
                    return FromDTO(desi);
			    }
            }
            catch(FailedToUpdateException x)
            {
                Console.WriteLine(x.Message);
                throw new Exception("Failed to update destination");
            }
			

		}
        public Destination SetDestinationStatus(Destination d, int id)
        {
            try
            {
                if (!Validate(d)) { return null; }
                else 
                {
                    _destinationRepository.SetDestinationStatus(ToDTO(d), id);
                    return d;
			    }
            }
            catch (CouldntSetDestinationStatusException c)
            {
                Console.WriteLine(c.Message);
                throw new Exception("Couldn't set destination status. Please try again");
            }

        }
        public Destination GetDestinationWithStatus(Destination des, int usrId)
        {
            try
            {
                if (!Validate(des)) { return null; }
                else
                {
                    var desi = _destinationRepository.GetStatusByUserIdAndDesId(ToDTO(des), usrId);
                    return FromDTO(desi);
			    }
            }
            catch (InvalidInformationException i)
            {
                Console.WriteLine(i.Message);
                throw new Exception("Invalid credentials. Couldn't Retreive destination.");
            }
        }
        public Destination UpdateStatusByUserIdAndDesId(Destination des, int usrId)
        {
            try
            {
                if (!Validate(des)) { return null; }
                else
                {
                    var desi = _destinationRepository.UpdateStatusByUserIdAndDesId(ToDTO(des), usrId);
                    return FromDTO(desi);
			    }
            }
            catch(InvalidInformationException i)
            {
                Console.WriteLine(i.Message);
                throw new Exception("Couldnt update status. Invalid id credentials");
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
            try
            {
                var allDes = _destinationRepository.AllDestinationsofUser(usrId);
                List<Destination> result = new List<Destination>();
                foreach(var d in allDes)
                {
                    result.Add(FromDTO(d));
                }
                return result.ToArray();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Couldn't find user. Invalid user credentials. Failed to load destinations of user.");
            }
		} 
        public Destination[] GetAllDestinations()
        {
            try
            {
                var desiList = _destinationRepository.GetAllDestinations();
                List<Destination> result = new List<Destination>();
                foreach(var d in desiList)
                {
                    result.Add(FromDTO(d));
                }
                return result.ToArray();
            }
            catch(FailedToRetrieveInformationException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Something went wrong.Failed to load destinations.Try again later.");
            }
		}
        public Destination GetDesById(int desId)
        {
            var des = _destinationRepository.GetDestinationById(desId);
            return FromDTO(des);

		}
		public bool Validate(Destination des)
        {
            var context = new ValidationContext(des);
            var results = new System.Collections.Generic.List<ValidationResult>();
            return Validator.TryValidateObject(des, context, results, true);
        }
    }
}
