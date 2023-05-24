using BusinessLogic;
using BusinessLogic.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class BusinessLogicTests
    {
		static IDestinationRepository _destinationRepository = new DestinationRepositoryTest();
		static IUserRepository _userRepository = new UserRepositoryTest();
		Security security = new Security();
       

		[TestMethod]
        public void UserAuthentication()
        {
            var email = "demonic@gmail.com";
            var pass = "123";

            var credentials = new UserDTO() { Email = email, Password = pass };

            var expectedResult = true;
            var actualResult = _userRepository.Authentication(credentials);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CreateUserInstanceFromDTO()
        {
            var userDTO = new UserDTO
            {
                Username = "test",
                Email = "test@gmail.com",
                Password = "123"
            };

            var result = new User
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password
            };

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(User));
            Assert.AreEqual(userDTO.Username, result.Username);
            Assert.AreEqual(userDTO.Email, result.Email);
            Assert.AreEqual(userDTO.Password, result.Password);
        }

        [TestMethod]
        public void Hashing()
        {
            var pass = "my password";

            var salt = security.CreateSalt();

            var expectedHash = security.CreateHash(salt, pass);

            var actualHash = security.CreateHash(salt, pass); 

            Assert.AreEqual(expectedHash, actualHash);
		}

		[TestMethod]
		public void CalvulateAverageRating()
		{
			var rating1 = 5;
			var rating2 = 3;
			var rating3 = 5;
			var des = new Destination();
			des.ratingList.Add(rating1);
			des.ratingList.Add(rating2);
			des.ratingList.Add(rating3);

			var expected = 4.33;

			var actual = des.CalculateAverage();

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}
	}
}