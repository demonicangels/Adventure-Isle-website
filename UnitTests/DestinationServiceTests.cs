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
			DestinationDTO d = new DestinationDTO() { Id = 5, Name = "Paris", AvgRating = 4.33, Climate = "Continental" };
			desService.InsertDestination(d);

			var result = desService.GetDesById(d.Id);
			var expected = d;

			Assert.IsNotNull(result);
			Assert.AreEqual(expected.Id, result.Id);
			Assert.AreEqual(expected.Name, result.Name);

		}

		[TestMethod]
		public void GetDesOfUser()
		{
			var result = desService.AllDesOfUser(234);

			var expected = 2;

			Assert.IsNotNull(result);
			Assert.AreEqual(expected, result.Length);
		}

		[TestMethod]
		public void GetDestinationsOfUser() 
		{
			var destinationsUser = desService.AllDesOfUser(234);

			Assert.IsNotNull(destinationsUser);
			Assert.IsTrue(destinationsUser.Count() == 2);
			Assert.AreEqual(destinationsUser.FirstOrDefault().Id, 1);
		}

		[TestMethod]
		public void UpdateDestination()
		{
			Destination des = new Destination(2, "Eindhoven", "","","","",5,null,234,null);

			var result = desService.UpdateDestination(des);
			var expected = des;

			Assert.IsNotNull(result);
			Assert.AreEqual(expected.Id, result.Id);
			Assert.AreEqual(expected.Name, result.Name);
			Assert.IsTrue(expected.UsrId == result.UsrId);
			Assert.IsNotNull(result.AvgRating);
		}

		[TestMethod]
		public void UodateDesStatus()
		{
            Destination des = new Destination(2, "Eindhoven", "", "", "", "", 5, null, 234, 1);

            var expected = des;
			var result = desService.UpdateStatusByUserIdAndDesId(des,234);

			Assert.IsNotNull(result);
			Assert.IsNotNull(result.DesStatus);
			Assert.AreEqual(result.DesStatus, expected.DesStatus);
		}
		[TestMethod]
		public void SearchDestination()
		{
			var search = "Ei";

			var expectedDes = new DestinationDTO() { Id = 2, Name = "Eindhoven", Climate = "Continental", UsrId = 234 };

			var actualDes = desService.GetDestinationByName(search);

			Assert.IsNotNull(actualDes);

            foreach(var des in actualDes)
            {
                Assert.AreEqual(expectedDes.Name, des.Name);
                Assert.AreEqual(expectedDes.Country, des.Country);
            }
		}
	}
}