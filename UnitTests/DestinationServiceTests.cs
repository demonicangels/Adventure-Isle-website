using BusinessLogic;
using BusinessLogic.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnitTests.MockData;

namespace UnitTests
{
    [TestClass]
    public class DestinationServiceTests
    {
		static IDestinationRepository _destinationRepository = new DestinationRepositoryTest();
		DestinationService desService = new DestinationService(_destinationRepository);

		[TestMethod]
		public void GetDestinationById()
		{
			DestinationDTO d = new DestinationDTO() { Id = 1, Name = "Paris", AvgRating = 4.5, Climate = "Continental" };
			desService.InsertDestination(d);

			var result = desService.GetDesById(d.Id);
			var expected = d;

			Assert.IsNotNull(result);
			Assert.AreEqual(expected.Id, result.Id);
			Assert.AreEqual(expected.Name, result.Name);

		}

		[TestMethod]
		public void GetDestinationsOfUser() 
		{
			DestinationDTO d = new DestinationDTO() { Id = 2, Name = "Eindhoven", UsrId = 234 };
			DestinationDTO de = new DestinationDTO() { Id = 3, Name = "Sofia", UsrId = 234 };
			DestinationDTO des = new DestinationDTO() { Id = 4, Name = "LA", UsrId = 123 };
			desService.InsertDestination(d);
			desService.InsertDestination(de);
			desService.InsertDestination(des);
			

			var destinationsUser = desService.AllDesOfUser(234);

			var expectedAtPositionZero = d;

			Assert.IsNotNull(destinationsUser);
			Assert.IsTrue(destinationsUser.Count() == 2);
			Assert.AreEqual(destinationsUser.FirstOrDefault().Id, 2);
		}

		[TestMethod]
		public void UpdateDestination()
		{
			Destination des = new Destination(4, "LA", "","","","",5,null,123,null);

			 var result = desService.UpdateDestination(des);
			des.AvgRating = 5;
			var expected = des;

			Assert.IsNotNull(result);
			Assert.AreEqual(expected.Id, result.Id);
			Assert.IsNotNull(result.AvgRating);
		}

		[TestMethod]
		public void UodateDesStatus()
		{
			Destination des = new Destination(4, "LA", "", "", "", "", 5, null, 123, 1);

			var expected = des;
			var result = desService.UpdateStatusByUserIdAndDesId(des,123);

			Assert.IsNotNull(result);
			Assert.IsNotNull(result.DesStatus);
			Assert.AreEqual(result.DesStatus, expected.DesStatus);
		}
		[TestMethod]
		public void SearchDestination()
		{
			var search = "Pa";
			var d = new DestinationDTO() { Name = "Provence", Country = "France" };
			var expectedDes = new DestinationDTO() { Name = "Paris", Country = "France" };

			_destinationRepository.InsertDestination(expectedDes);
			_destinationRepository.InsertDestination(d);

			var actualDes = _destinationRepository.GetDestinationByName(search);

			Assert.IsNotNull(actualDes);
            foreach(var des in actualDes)
            {
                Assert.AreEqual(expectedDes.Name, des.Name);
                Assert.AreEqual(expectedDes.Country, des.Country);
            }
		}
	}
}