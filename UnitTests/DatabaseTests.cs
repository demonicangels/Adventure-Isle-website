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
    public class DatabaseTests
    {
        IDestinationRepositorytest _destinationRepository = new DestinationRepositoryTest();
        IUserRepositoryTest _userRepository = new UserRepositoryTest();

        [TestMethod]
        public void GetUserByEmail()
        {
            var user1 = new UsersTest(null, "demonic@gmail.com", "123") { Username = "demonic", UserSince = DateTime.Parse("3/30/2023"), Birthday = DateTime.Parse("10/4/2002"), Bio = "If you are not travelling then what are you doing?" };
            var user2 = new UsersTest(null, "angel@gmail.com", "123") { Username = "angel", UserSince = DateTime.Parse("3/30/2023"), Birthday = DateTime.Parse("10/4/2002"), Bio = "If you are not travelling then what are you doing?" };
            _userRepository.InsertUser(user1, "", "");
            _userRepository.InsertUser(user2, "", "");

            var expectedUser = new UsersTest(null, "angel@gmail.com","123") { Username = "angel", UserSince = DateTime.Parse("3/30/2023 4:12:44 PM"), Birthday = DateTime.Parse("10/4/2002"), Bio = "If you are not travelling then what are you doing?" };

            var actualUser = _userRepository.GetUserByEmail("angel@gmail.com");

            Assert.IsNotNull(actualUser);
            Assert.AreEqual(expectedUser.Username, actualUser.Username);
            Assert.AreEqual(expectedUser.Email, actualUser.Email);
            Assert.AreEqual(expectedUser.Birthday, actualUser.Birthday);
            Assert.AreEqual(expectedUser.Bio, actualUser.Bio);
            Assert.AreEqual(expectedUser.UserSince.Date, actualUser.UserSince.Date);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var name = "test";
            var birthday = DateTime.Parse("10/4/2002 4:20:00 PM");
            var email = "test@gmail.com";
            UsersTest user = new UsersTest(null, email,"123") { Username = name, Birthday = birthday, Bio = "Testing for bugs and eradicating them." };
            _userRepository.InsertUser(user, "", "");

            UserDTO expectedResult = null;

            _userRepository.DeleteUser(email);

            var actualResult = _userRepository.GetUserByEmail(email);

            Assert.IsNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

		[TestMethod]
		public void SearchDestination()
		{
			var search = "Pa";
			var d = new DestinationsTest() { Name = "Provence", Country = "France" };
			var expectedDes = new DestinationsTest() { Name = "Paris", Country = "France" };

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