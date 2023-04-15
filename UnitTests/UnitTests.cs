using BusinessLogic;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        IDestinationRepository _destinationRepository = new DestinationRepositoryTest();
        IUserRepository _userRepository = new UserRepositoryTest();

        [TestMethod]
        public void GetUserByEmail()
        {
            var user1 = new UserDTO() { Username = "demonic", Email = "demonic@gmail.com", Password = "123", UserSince = DateTime.Parse("3/30/2023 4:12:44 PM"), Birthday = DateTime.Parse("10/4/2002 4:20:00 PM"), Bio = "If you are not travelling then what are you doing?" };
            var user2 = new UserDTO() { Username = "angel", Email = "angel@gmail.com", Password = "123", UserSince = DateTime.Parse("3/30/2023 4:12:44 PM"), Birthday = DateTime.Parse("10/4/2002 4:20:00 PM"), Bio = "If you are not travelling then what are you doing?" };
            _userRepository.InsertUser(user1, "", "");
            _userRepository.InsertUser(user2, "", "");

            var expectedUser = new UserDTO() { Username = "angel", Email = "angel@gmail.com", Password = "123", UserSince = DateTime.Parse("3/30/2023 4:12:44 PM"), Birthday = DateTime.Parse("10/4/2002 4:20:00 PM"), Bio = "If you are not travelling then what are you doing?" };

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
            UserDTO user = new UserDTO { Username = name, Email = email, Password = "123", Birthday = birthday, Bio = "Testing for bugs and eradicating them." };
            _userRepository.InsertUser(user, "", "");

            UserDTO expectedResult = null;

            _userRepository.DeleteUser(email);

            var actualResult = _userRepository.GetUserByEmail(email);

            Assert.IsNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }
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
            var keysize = 20;
            var iterations = 350000;
            var hashAlgorithm = HashAlgorithmName.SHA512;
            var pass = "my password";


            var salt_bytes = RandomNumberGenerator.GetBytes(keysize);
            var salt = Convert.ToHexString(salt_bytes);

            var hashing = Rfc2898DeriveBytes.Pbkdf2(
				Encoding.UTF8.GetBytes(pass),
				Convert.FromHexString(salt),
				iterations,
				hashAlgorithm,
				keysize);

            var expectedHash = Convert.ToHexString(hashing);

            var hashing2 = Rfc2898DeriveBytes.Pbkdf2(
				Encoding.UTF8.GetBytes(pass),
				Convert.FromHexString(salt),
				iterations,
				hashAlgorithm,
				keysize);

            var actualHash = Convert.ToHexString(hashing2); 

            Assert.AreEqual(expectedHash, actualHash);

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
			Assert.AreEqual(expectedDes.Name, actualDes.Name);
			Assert.AreEqual(expectedDes.Country, actualDes.Country);
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