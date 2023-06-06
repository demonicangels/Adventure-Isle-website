using BusinessLogic;
using BusinessLogic.Entities;
using DAL;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnitTests.MockData;

namespace UnitTests
{
    [TestClass]
    public class UserServiceTests
    {
		
		static IUserRepository _userRepository = new UserRepositoryTest();
        UserService userService = new UserService(_userRepository);
		Security security = new Security();

		[TestMethod]
		public void CreateUserInstanceFromDTO()
		{
			var userDTO = new UserDTO()
			{
				Username = "test",
				Email = "test@gmail.com",
				Password = "123"
			};

			var result = new User(0, userDTO.Email, userDTO.Password)
			{
				Username = userDTO.Username,
			};

			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(User));
			Assert.AreEqual(userDTO.Username, result.Username);
			Assert.AreEqual(userDTO.Email, result.Email);
			Assert.AreEqual(userDTO.Password, result.Password);
		}

		[TestMethod]
		public void InsertUser()
		{
			UserDTO user = new UserDTO()
			{
				Username = "Malcolm",
				Email = "nz@gmail.com",
				Password = "123",
			};
			var result = userService.InsertUser(user, "", "");

			Assert.IsNotNull(result);
			Assert.AreEqual(result.GetType(), typeof(UserDTO));
		}

		[TestMethod]
		public void GetUserByEmail()
		{
			var user1 = new UserDTO() { Email = "demonic@gmail.com", Password = "123", Username = "demonic", UserSince = DateTime.Parse("3/30/2023"), Birthday = DateTime.Parse("10/4/2002"), Bio = "If you are not travelling then what are you doing?" };
			var user2 = new UserDTO() { Email = "angel@gmail.com", Password = "123", Username = "angel", UserSince = DateTime.Parse("3/30/2023"), Birthday = DateTime.Parse("10/4/2002"), Bio = "If you are not travelling then what are you doing?" };
			_userRepository.InsertUser(user1, "", "");
			_userRepository.InsertUser(user2, "", "");

			var expectedUser = new UserDTO() { Email = "angel@gmail.com", Password = "123", Username = "angel", UserSince = DateTime.Parse("3/30/2023 4:12:44 PM"), Birthday = DateTime.Parse("10/4/2002"), Bio = "If you are not travelling then what are you doing?" };

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
			UserDTO user = new UserDTO() { Email = email, Password = "123", Username = name, Birthday = birthday, Bio = "Testing for bugs and eradicating them." };
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

			var salt = security.CreateSalt();
			var hash = security.CreateHash(salt, pass);
			credentials.HashedPass = hash;

			_userRepository.InsertUser(credentials, salt, hash);

			var expectedResult = new User(null, email, null) {HashedPass = credentials.HashedPass, Salt = credentials.Salt};
            var actualResult = userService.Authenticate(credentials.Email, credentials.Password);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult.GetType(), actualResult.GetType());
			Assert.AreEqual(credentials.Email, expectedResult.Email);
        }

		[TestMethod]
		public void GetAllUsers() 
		{
			var result = userService.GetUsers();

			Assert.IsNotNull(result);
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
        public void DataValidationTestTrue()
        {
            User usr = new User(1, "hi", "");
            var finalResult = userService.Validate(usr);
            

            var expectedFinalResult = true;

            Assert.IsNotNull(finalResult);
            Assert.AreEqual(expectedFinalResult, finalResult);
        }

		[TestMethod]
		public void InfoValidation()
		{
			var expected = true;
			var result = userService.InfoValidation("0", "hi");

			Assert.IsNotNull(result);
			Assert.AreEqual(expected, result);
		}
	}
}