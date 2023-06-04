using BusinessLogic;
using BusinessLogic.Entities;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnitTests.MockData;

namespace UnitTests
{
    [TestClass]
    public class BusinessLogicTests
    {
		static IDestinationRepositorytest _destinationRepository = new DestinationRepositoryTest();
		static IUserRepositoryTest _userRepository = new UserRepositoryTest();
		Security security = new Security();
       

		[TestMethod]
        public void UserAuthentication()
        {
            var email = "demonic@gmail.com";
            var pass = "123";

            var credentials = new UsersTest(null, email, pass);

            var expectedResult = true;
            var actualResult = _userRepository.Authentication(credentials);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CreateUserInstanceFromDTO()
        {
            var userDTO = new UserDTO(0, "test@gmail.com","123")
            {
                Username = "test",
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
            ReviewsTest rev = new ReviewsTest(1, "hi");
            var context = new ValidationContext(rev);
            var results = new System.Collections.Generic.List<ValidationResult>();
            var finalResult = Validator.TryValidateObject(rev, context, results, true);

            var expectedFinalResult = true;

            Assert.IsNotNull(finalResult);
            Assert.AreEqual(expectedFinalResult, finalResult);
            Assert.AreEqual(rev, context.ObjectInstance);
        }
	}
}